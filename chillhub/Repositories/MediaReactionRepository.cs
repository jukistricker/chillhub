using Azure.Core;
using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class MediaReactionRepository : Repository<MediaReaction>, IMediaReactionRepository
    {
        public MediaReactionRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<MediaReaction>> GetReactionsAsync(List<Guid> userIds, List<Guid> mediaIds)
        {
            if (userIds == null || !userIds.Any() || mediaIds == null || !mediaIds.Any())
            {
                return new List<MediaReaction>();
            }

            return await _dbSet
                .Where(r => userIds.Contains(r.UserId) && mediaIds.Contains(r.MediaId))
                .ToListAsync();
        }

        public async Task<CursorResponse<MediaReaction>> GetCursorReactionsAsync(MediaReactionFilterRequest request)
        {
            var query = GetQueryable().AsNoTracking();

            query = query.Where(x => x.UserId == request.UserId
            && x.MediaId==request.MediaId);

            return await GetByCursorAsync(query, request, u => u.Id);
        }
    }
}
