using chillhub.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Configurations;

public class PermissionGroupConfiguration : IEntityTypeConfiguration<PermissionGroup>
{
    public void Configure(EntityTypeBuilder<PermissionGroup> builder)
    {
        builder.HasKey(pg => pg.Id);

        builder.Property(pg => pg.Name).IsRequired().HasMaxLength(150);
        builder.Property(pg => pg.Code).IsRequired().HasMaxLength(100);
        builder.Property(pg => pg.SortOrder).IsRequired();

        builder.HasIndex(pg => pg.Code).IsUnique();

        builder.HasMany(pg => pg.Permissions)
            .WithOne(p => p.PermissionGroup)
            .HasForeignKey(p => p.PermissionGroupId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}