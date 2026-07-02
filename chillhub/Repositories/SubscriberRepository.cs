using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class SubscriberRepository : Repository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Subscriber?> GetAsync(Guid subscriberId, Guid channelId)
        {
            return await _dbSet
                .FirstOrDefaultAsync(s => s.SubscriberId == subscriberId && s.ChannelId == channelId);
        }

        public async Task<List<Guid>> GetSubscriberIdsByChannelIdAsync(Guid channelId)
        {
            return await _dbSet
                .Where(s => s.ChannelId == channelId && s.IsNotice)
                .Select(s => s.SubscriberId) // Chỉ lấy mỗi Id cho nhanh
                .ToListAsync();
        }

        public async Task<CursorResponse<Subscriber>> GetSubscribersAsync(SubscriberFilterRequest request)
        {
            IQueryable<Subscriber> query = _dbSet.AsNoTracking();
            query = query.Include(s => s.Channel);
            query= query.Where(x=>x.SubscriberId == request.SubscriberId);
        
            if (request.ChannelId.HasValue)
                query = query.Where(x => x.ChannelId == request.ChannelId);
            
            return await GetByCursorAsync(query, request, u => u.Id);
        }
    }
}
