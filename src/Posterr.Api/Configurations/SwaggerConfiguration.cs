using Microsoft.OpenApi.Models;

namespace Posterr.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Posterr",
                    Description = "Posterr API",
                    Contact = new OpenApiContact { Name = "Pablo Christian Pereira Nazareth", Email = "snakepablo@hotmail.com" },
                });
                s.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        public static void UseSwaggerSetup(this IApplicationBuilder app)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));

            app.UseSwagger(c => { c.RouteTemplate = "/swagger/{documentName}/swagger.json"; });
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Posterr v1.0");});
        }
    }
}
