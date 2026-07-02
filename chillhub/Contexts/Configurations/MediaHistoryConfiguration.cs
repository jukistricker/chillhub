using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace chillhub.Contexts.Configurations
{
    public class MediaHistoryConfiguration : IEntityTypeConfiguration<MediaHistory>
    {
        public void Configure(EntityTypeBuilder<MediaHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(h => new { h.UserId, h.MediaId })
                .IsUnique();

        }
    }
}
