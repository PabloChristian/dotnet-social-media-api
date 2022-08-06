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

            builder.HasOne(x => x.User)
                .WithMany(x => x.PostMessage)
                .HasForeignKey(x => x.UserName)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Repost)
                .WithMany(x => x.Reposts)
                .HasForeignKey(x => x.RepostId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
