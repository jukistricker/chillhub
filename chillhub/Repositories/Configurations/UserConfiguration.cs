using chillhub.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(u => u.Email)
            .HasMaxLength(255);

        builder.Property(u => u.FullName)
            .HasMaxLength(255);

        builder.Property(u => u.Provider)
            .HasMaxLength(50);

        builder.Property(u => u.ExternalId)
            .HasMaxLength(255);

        builder.Property(u => u.Lang)
            .IsRequired()
            .HasConversion<int>();

        builder.HasIndex(u => u.Username).IsUnique();

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}