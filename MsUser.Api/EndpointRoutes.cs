using MsUser.Api.Endpoints.V1.Users.Routes;

namespace MsUser.Api
{
    public static class EndpointRoutes
    {
        public static void ConfigureEndpoints(this WebApplication app)
        {
            app.MapUserEndpoints();
        }
    }
}