using Posterr.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Posterr.Infrastructure.Data.Mapping
{
    public class MessageMapping : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Consumer)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Sender)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Message)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
