using Posterr.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Posterr.Infrastructure.Data.Mapping
{
    public class PostMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.PostMessage);
            builder.Property(x => x.UserId);
            builder.Property(x => x.UserName);
            builder.Property(x => x.RepostId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.PostMessage)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Repost)
                .WithMany(x => x.Reposts)
                .HasForeignKey(x => x.RepostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
