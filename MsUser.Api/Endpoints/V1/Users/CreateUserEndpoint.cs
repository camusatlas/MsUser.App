using Google.Apis.Util;
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
    public class CreateUserEndpoint
    {
        public record CreateUserRequest(
            string Name,
            string Mail,
            string Password);

        public static async Task<Results<Ok<CreateUserResult>, BadRequest<ValidationResult>, NotFound, Conflict, ProblemHttpResult>>
        DoAsync(
            [FromBody] CreateUserRequest request,
            [FromServices] IMessageBus bus,
            CancellationToken ct)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(bus, nameof(bus));

                if (request is null)
                    return TypedResults.Problem(
                        ValidationsMessages.RequestBodyEmpty,
                        statusCode: StatusCodes.Status400BadRequest);

                var command = new CreateUserCommand(
                    request.Name,
                    request.Mail,
                    request.Password);

                var result = await bus.InvokeAsync<CommandResult<CreateUserResult>>(command, ct);

                return result.PrepareResponse(result.Info);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(
                    detail: ex.Message,
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}