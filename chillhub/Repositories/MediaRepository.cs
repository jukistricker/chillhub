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
            var query = GetQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
                query = query.Where(x => x.Title.Contains(request.Search));

            if (request.UserId.HasValue)
                query = query.Where(x => x.UserId == request.UserId);
            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id);

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type);

            query=query.Include(x => x.User);

            return await GetByCursorAsync(query, request, u => u.Id);
        }

        public async Task<List<Media>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<HashSet<Guid>> GetValidMediaIds(IEnumerable<Guid> mediaIds)
        {
            List<Guid> list = await _dbSet
                .Where(u => mediaIds.Contains(u.Id))
                .Select(u => u.Id)
                .ToListAsync();

            return new HashSet<Guid>(list);
        }
    }
}