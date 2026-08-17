using RealPlaza.Web.Web.Middleware.ExceptionHandling;
using System.Net;

namespace MsUser.Api.Endpoints.V1.Users.Routes
{
    public static class UserRoutes
    {
        internal static void MapUserEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/v1/users")
                .CacheOutput(b => b.NoCache())
                .WithTags("User");
            group.MapGet("", GetUserBySearchEndpoint.DoAsync)
                .Produces<HttpStatusCodeInfo>(500);

            group.MapGet("/pagination", GetUserPaginationEndpoint.DoAsync)
                .Produces<HttpStatusCodeInfo>(500);

            group.MapPost("", CreateUserEndpoint.DoAsync)
                .Produces<HttpStatusCodeInfo>(500);

            group.MapPut("/{id}", UpdateUserEndpoint.DoAsync)
                .Produces<HttpStatusCodeInfo>(500);
        }
    }
}
