using Posterr.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Posterr.Tests.Fixture
{
    public class PosterrDbContextFixure
    {
        protected PosterrContext db;

        protected static DbContextOptions<PosterrContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<PosterrContext>();
            builder.UseInMemoryDatabase("PosterrDbTest")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected static PosterrContext GetDbInstance() => new(CreateNewContextOptions());
    }
}
