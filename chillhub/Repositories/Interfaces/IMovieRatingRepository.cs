using chillhub.Entities.Media;

namespace chillhub.Repositories.Interfaces
{
    public interface IMovieRatingRepository:IRepository<MovieRating>
    {
        Task<MovieRating?> GetByMovieIdAsync(Guid MovieId, Guid userId);
        Task<MovieRating?> GetByIdAsync(Guid id, Guid userId);
    }
}
