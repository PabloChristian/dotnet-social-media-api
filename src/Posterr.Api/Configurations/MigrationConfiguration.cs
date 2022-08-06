using Microsoft.EntityFrameworkCore;

namespace Posterr.Api.Configurations
{
    public static class MigrationConfiguration
    {
        public static void AddMigration<T>(this IApplicationBuilder app) where T : Posterr.Infrastructure.Data.Context.PosterrContext
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<T>();
            dbContext?.Database.Migrate();
        }
    }
}