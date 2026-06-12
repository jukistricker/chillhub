using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class MediaRepository : Repository<Media>, IMediaRepository
    {
        public MediaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CursorResponse<Media>> GetMediasAsync(MediaFilterRequest request)
        {
            var query = GetQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(x => x.Title.Contains(request.Title));

            if (request.UserId.HasValue)
                query = query.Where(x => x.UserId == request.UserId);

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type);

            return await GetByCursorAsync(query, request, u => u.Id);
        }

        public async Task<List<Media>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}