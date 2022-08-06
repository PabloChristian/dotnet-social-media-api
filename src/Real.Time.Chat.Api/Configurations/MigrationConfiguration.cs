using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Posterr.Api.Configurations
{
    public static class MigrationConfiguration
    {
        public static void AddMigration<T>(this IApplicationBuilder app) where T : Posterr.Infrastructure.Data.Context.PosterrChatContext
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<T>();
            dbContext?.Database.Migrate();
        }
    }
}