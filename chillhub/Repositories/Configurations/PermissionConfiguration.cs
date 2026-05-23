using chillhub.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
        builder.Property(p => p.Code).IsRequired().HasMaxLength(150);
        builder.HasIndex(p => p.Code).IsUnique();

        builder.HasOne(p => p.PermissionGroup)
            .WithMany(g => g.Permissions)
            .HasForeignKey(p => p.PermissionGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.RolePermissions)
            .WithOne(rp => rp.Permission)
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}