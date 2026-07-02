using chillhub.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace chillhub.Contexts.Configurations
{
    public class MovieRatingConfiguration : IEntityTypeConfiguration<MovieRating>
    {
        public void Configure(EntityTypeBuilder<MovieRating> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MovieId)
                .IsRequired();

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.Rating)
                .IsRequired();

            builder.Property(x => x.RatingCount)
                .IsRequired()
                .HasDefaultValue(1);

            builder.HasIndex(x => new { x.MovieId, x.UserId })
                .IsUnique();


        }
    }
}