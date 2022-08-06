using Posterr.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Posterr.Tests.Fixture
{
    public class PosterrChatDbContextFixure
    {
        protected PosterrChatContext db;

        protected static DbContextOptions<PosterrChatContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<PosterrChatContext>();
            builder.UseInMemoryDatabase("PosterrDbTest")
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected static PosterrChatContext GetDbInstance() => new(CreateNewContextOptions());
    }
}
