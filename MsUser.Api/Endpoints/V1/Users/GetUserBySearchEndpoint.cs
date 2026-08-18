using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MsUser.Internal.Contract.User.Queries.QueryResult;
using MsUser.Internal.Contract.Users.Queries;
using RealPlaza.Core.Common.Contracts;
using RealPlaza.Core.Core.Configuration;
using Wolverine;

namespace MsUser.Api.Endpoints.V1.Users
{
    public class GetUserBySearchEndpoint
    {
        public static async Task<Results<Ok<GetUserBySearchResult>, BadRequest<ValidationResult>, NotFound, Conflict, ProblemHttpResult>>
        DoAsync(
            [FromQuery] int? id,
            [FromQuery] string? name,
            [FromQuery] string? mail,
            [FromQuery] bool? asset,
            [FromQuery] int? state,
            [FromServices] IMessageBus bus,
            CancellationToken ct)
        {
            ArgumentNullException.ThrowIfNull(bus, nameof(bus));
            var query = new GetUserBySearch(
                id,
                name,
                mail,
                asset,
                state
            );
            var result = await bus.InvokeAsync<QueryResult<GetUserBySearchResult>>(query, ct);
            return result.PrepareResponse();
        }
    }
}
