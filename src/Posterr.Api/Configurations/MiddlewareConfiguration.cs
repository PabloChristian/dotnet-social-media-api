using Posterr.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
