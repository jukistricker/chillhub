using chillhub.Entities;
using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Dapper.SqlMapper;

namespace chillhub.Contexts.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(c => c.User)
          .WithMany() 
          .HasForeignKey(c => c.UserId)
          .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
