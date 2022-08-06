using Posterr.Api.Middlewares;

namespace Posterr.Api.Configurations
{
    public static class MiddlewareConfiguration
    {
        public static void AddMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestHandlerMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseMiddleware<ResponseHandlerMiddleware>();
        }
    }
}
