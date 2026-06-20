using chillhub.Entities.Auth;
using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace chillhub.Contexts.Configurations;

public class MediaCategoryConfiguration : IEntityTypeConfiguration<MediaCategory>
{
    public void Configure(EntityTypeBuilder<MediaCategory> builder)
    {
        builder.HasKey(mc => new { mc.MediaId, mc.CategoryId });

        builder.HasOne(ur => ur.Media)
            .WithMany(u => u.MediaCategories)
            .HasForeignKey(ur => ur.MediaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ur => ur.Category)
            .WithMany(r => r.MediaCategories)
            .HasForeignKey(ur => ur.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


        // Đánh Index cho RoleId để tối ưu các câu lệnh quét ngược 
        builder.HasIndex(ur => ur.CategoryId);
    }
}