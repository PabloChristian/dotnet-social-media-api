using Posterr.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Posterr.Infrastructure.Data.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserScreenName).IsRequired();
            builder.Property(x => x.ProfileImageUrl);
            builder.Property(x => x.Created);

            CreateSeed(builder);
        }

        private static void CreateSeed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User() {
                Id = Guid.NewGuid(),
                UserName = "test1",
                UserScreenName = "test1",
                ProfileImageUrl = "",
                Created = DateTime.Now
            });

            builder.HasData(new User()
            {
                Id = Guid.NewGuid(),
                UserName = "test2",
                UserScreenName = "test2",
                ProfileImageUrl = "",
                Created = DateTime.Now
            });

            builder.HasData(new User()
            {
                Id = Guid.NewGuid(),
                UserName = "test3",
                UserScreenName = "test3",
                ProfileImageUrl = "",
                Created = DateTime.Now
            });

            builder.HasData(new User()
            {
                Id = Guid.NewGuid(),
                UserName = "test4",
                UserScreenName = "test4",
                ProfileImageUrl = "",
                Created = DateTime.Now
            });
        }
    }
}
