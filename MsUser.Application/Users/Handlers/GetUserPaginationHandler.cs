using Microsoft.Extensions.Logging;
using MsUser.Application.Users.Validators;
using MsUser.Internal.Contract.Users.Queries;
using MsUser.Internal.Contract.Users.Queries.QueryResult;
using MsUser.Persistence.Users.Queries;
using RealPlaza.Core.Common.Contracts;

namespace MsUser.Application.Users.Handlers
{
    public class GetUserPaginationHandler
    {
        private readonly ILogger<GetUserPaginationHandler> _logger;
        private readonly IUsuarioQuery _queries;
        private readonly GetUserPaginationRequestValidator _validator;
        public GetUserPaginationHandler(ILogger<GetUserPaginationHandler> logger, GetUserPaginationRequestValidator validator, IUsuarioQuery queries)
        {
            _logger = logger;
            _validator = validator;
            _queries = queries;
        }
        public async Task<QueryResult<GetUserPaginationResult>> HandleAsync(GetUserPagination query, CancellationToken ct)
        {
            ArgumentNullException.ThrowIfNull(query);
            try
            {
                var validation = _validator.Validate(query);
                if (!validation.IsValid)
                    return new QueryResult<GetUserPaginationResult>(ResultStatus.FailedValidation, new ValidationResult(validation.ToDictionary()));

                var paging = query.Paging ?? new Paging(1, Constants.DefaultPageSize);

                var rows = await _queries.GetUserPagination(
                    query.name,
                    paging.CurrentIndex,
                    paging.PageSize,
                    query.SortColumn,
                    query.SortDirection);
                var list = rows.ToList();

                if (!string.IsNullOrWhiteSpace(query.name) && list.Any())
                {
                    var usuario = list.First();
                    if (string.IsNullOrWhiteSpace(usuario.name))
                    {
                        var errorDict = new Dictionary<string, string[]>
                        {
                            [UserErrorCodes.UserNameEmpty] = new[] { ValidationMessages.UserNameEmpty } 
                        };
                        return new QueryResult<GetUserPaginationResult>(ResultStatus.FailedValidation, new ValidationResult(errorDict));
                    }
                }
                var totalRows = list.FirstOrDefault()?.TotalRows ?? 0;
                var items = list.Select(x => new UserItemResult(
                    x.id,
                    x.name ?? string.Empty,
                    x.mail ?? string.Empty,
                    x.asset,
                    x.state
                ));

                var pagingResult = new PagingResult(paging.CurrentIndex, paging.PageSize, totalRows);
                var payload = new GetUserPaginationResult(items, pagingResult);

                return new QueryResult<GetUserPaginationResult>(ResultStatus.Success, Data: payload);
            }
            catch (Exception e)
            {
                _logger.LogError(e, string.Format(LogConstants.LogErrorMessage, nameof(GetUserPaginationHandler)));
                return new QueryResult<GetUserPaginationResult>(ResultStatus.FailedExecution);
            }
        }
    }
}