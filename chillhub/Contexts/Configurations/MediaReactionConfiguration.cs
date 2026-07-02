using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Contexts.Configurations
{
    public class MediaReactionConfiguration : IEntityTypeConfiguration<MediaReaction>
    {
        public void Configure(EntityTypeBuilder<MediaReaction> builder)
        {
            // 1. Khai báo Khóa chính
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => new { x.UserId, x.MediaId })
                   .IsUnique();

            builder.Property(x => x.ReactionType)
                   .HasConversion<int>()
                   .IsRequired();

        }
    }
}