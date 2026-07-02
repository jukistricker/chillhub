using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class MovieRatingRepository : Repository<MovieRating>, IMovieRatingRepository
    {
        public MovieRatingRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<MovieRating?> GetByMovieIdAsync(Guid MovieId, Guid userId)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.MovieId == MovieId && r.UserId==userId);
                
        }

        public async Task<MovieRating?> GetByIdAsync(Guid id, Guid userId)
        {
            return await _dbSet.FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);

        }
    }
}
