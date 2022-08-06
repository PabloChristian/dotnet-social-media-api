using Posterr.Domain.Entity;
using Posterr.Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Posterr.Shared.Kernel.Entity;

namespace Posterr.Infrastructure.Data.Context
{
    public class PosterrContext : DbContext
    {
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public PosterrContext(DbContextOptions<PosterrContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
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

            optionsBuilder.UseSqlServer(config.GetConnectionString("PosterrConnection"));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var localZone = TimeZoneInfo.Local;

            foreach (var entry in ChangeTracker.Entries<EntityAudit>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.TimeZone = localZone.DisplayName;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.UtcNow;
                        entry.Entity.TimeZone = localZone.DisplayName;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
