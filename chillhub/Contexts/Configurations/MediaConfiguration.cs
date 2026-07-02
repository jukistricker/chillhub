using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Contexts.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(m => m.Description)
                .HasMaxLength(2000);

            builder.Property(m => m.Thumbnail)
                .HasMaxLength(1000);

            builder.Property(m => m.Type)
                .IsRequired()
                .HasConversion<int>();

            builder.Property(m => m.MediaStatus)
                .IsRequired()
                .HasConversion<int>();

            builder.HasOne(m => m.User)
                .WithMany(u=>u.Medias) 
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(m => m.MediaCategories)
                .WithOne(mc => mc.Media)
                .HasForeignKey(mc => mc.MediaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}