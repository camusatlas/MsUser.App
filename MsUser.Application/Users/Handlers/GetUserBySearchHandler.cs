using Microsoft.Extensions.Logging;
using MsUser.Application.Users.Validators;
using MsUser.Internal.Contract.User.Queries.QueryResult;
using MsUser.Internal.Contract.Users.Queries;
using MsUser.Persistence.Users.Queries;
using RealPlaza.Core.Common.Contracts;
using MsUser.Application;

namespace MsUser.Application.Users.Handlers
{
    public class GetUserBySearchHandler
    {
        private readonly ILogger<GetUserBySearchHandler> _logger;
        private readonly GetUsersBySearchValidator _validator;
        private readonly IUsuarioQuery _usuarioQuery;
        public GetUserBySearchHandler(ILogger<GetUserBySearchHandler> logger, GetUsersBySearchValidator validator, IUsuarioQuery usuarioQuery)
        {
            _logger = logger;
            _validator = validator;
            _usuarioQuery = usuarioQuery;
        }
        public async Task<QueryResult<GetUserBySearchResult>> HandleAsync(GetUserBySearch query, CancellationToken ct)
        {
            ArgumentNullException.ThrowIfNull(query, nameof(query));
            try
            {
                var normalizedId = query.id;
                var normalizename = query.name;
                var normalzemail = query.mail;
                var normalizeQuery = new GetUserBySearch(normalizedId, normalizename, normalzemail, query.asset, query.state);
                var validatorResult = await _validator.ValidateAsync(normalizeQuery, ct);
                if (!validatorResult.IsValid)
                {
                    _logger.LogWarning("Validation failed for GetUserBySearch. Error: {Errors}", string.Join("; ", validatorResult.Errors.Select(e => $"{e.PropertyName}:{e.ErrorMessage}")));
                    return new QueryResult<GetUserBySearchResult>(ResultStatus.FailedValidation, new ValidationResult(validatorResult.ToDictionary()));
                }
                var usuario = await _usuarioQuery.GetBySearch(
                    normalizedId,
                    normalizename,
                    normalzemail,
                    normalizeQuery.asset,
                    normalizeQuery.state);
                if (normalizeQuery.id > 0 && usuario.Any())
                {
                    var user = usuario.First();
                    if (string.IsNullOrWhiteSpace(user.name))
                    {
                        _logger.LogWarning("The user with Id {UserId} has an empty or null name", normalizedId);
                        var errorDict = new Dictionary<string, string[]>
                        {
                            [UserErrorCodes.UserNameEmpty] = new[] { ValidationMessages.UserNameEmpty }
                        };
                        return new QueryResult<GetUserBySearchResult>(ResultStatus.FailedValidation, new ValidationResult(errorDict));
                    }
                }
                _logger.LogInformation("User query successful. Parameters: id = {id}, name = {name}, mail = {mail}, asset = {asset}. Results: {Count}", normalizeQuery.id, normalizeQuery.name, normalizeQuery.mail, normalizeQuery.asset, usuario.Count());
                var userResult = usuario.Select(x => new UserItem(
                    x.id,
                    x.name ?? string.Empty,
                    x.mail ?? string.Empty,
                    x.asset,
                    x.state
                ));
                var result = new GetUserBySearchResult(userResult);
                return new QueryResult<GetUserBySearchResult>(ResultStatus.Success, Data: result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Unhandled error in GetUserBySearchHandler. Parameters: id = {id}, name = {name}, mail = {mail}, asset = {asset}", query.id, query.name, query.mail, query.asset);
                return new QueryResult<GetUserBySearchResult>(ResultStatus.FailedExecution);
            }
        } 
    }
}
