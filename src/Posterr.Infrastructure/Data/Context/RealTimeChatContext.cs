using Posterr.Domain.Entity;
using Posterr.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Posterr.Infrastructure.Data.Context
{
    public class PosterrChatContext : DbContext
    {
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public PosterrChatContext(DbContextOptions<PosterrChatContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                 .AddJsonFile($"appsettings.Development.json")
#else
                 .AddJsonFile($"appsettings.Production.json")
#endif
                 .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("PosterrChatConnection"));
        }
    }
}
