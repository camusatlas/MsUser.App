using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MsUser.Application;
using MsUser.Internal.Contract.User.Commands.CommandResult;
using MsUser.Internal.Contract.Users.Commands;
using RealPlaza.Core.Common.Contracts;
using RealPlaza.Core.Core.Configuration;
using Wolverine;

namespace MsUser.Api.Endpoints.V1.Users
{
    public class UpdateUserEndpoint
    {
        public record UpdateUserRequest(
            bool Asset);

        public static async Task<Results<Ok<UpdateUserResult>, BadRequest<ValidationResult>, NotFound, Conflict, ProblemHttpResult>>
        DoAsync(
            [FromRoute] int id,
            [FromBody] UpdateUserRequest request,
            [FromServices] IMessageBus bus,
            CancellationToken ct)
        {
            if (request is null)
                return TypedResults.Problem(
                    ValidationsMessages.RequestBodyEmpty,
                    statusCode: StatusCodes.Status400BadRequest);

            var command = new UpdateUserCommand(
                id,
                request.Asset);

            var result = await bus.InvokeAsync<CommandResult<UpdateUserResult>>(command, ct);

            return result.PrepareResponse(result.Info);
        }
    }
}