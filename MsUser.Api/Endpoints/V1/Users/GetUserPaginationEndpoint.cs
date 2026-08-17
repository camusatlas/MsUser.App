using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MsUser.Internal.Contract.Users.Queries;
using MsUser.Internal.Contract.Users.Queries.QueryResult;
using RealPlaza.Core.Common.Contracts;
using RealPlaza.Core.Core.Configuration;
using Wolverine;

namespace MsUser.Api.Endpoints.V1.Users
{
    public class GetUserPaginationEndpoint
    {
        public static async Task<Results<Ok<GetUserPaginationResult>, BadRequest<ValidationResult>,NotFound, Conflict, ProblemHttpResult>>
        DoAsync(
            [FromQuery] string? name,
            [FromQuery] int? pageCurrent,
            [FromQuery] int? pageSize,
            [FromQuery] string sortColumn,
            [FromQuery] string sortDirection,
            [FromServices] IMessageBus bus,
            CancellationToken ct)
        {
            ArgumentNullException.ThrowIfNull(bus, nameof(bus));
            var query = new GetUserPagination(name, new Paging(pageCurrent ?? 1, pageSize ?? Application.Constants.DefaultPageSize), sortColumn, sortDirection);
            var result = await bus.InvokeAsync<QueryResult<GetUserPaginationResult>>(query, ct);
            return result.PrepareResponse();
        }
    }
}
