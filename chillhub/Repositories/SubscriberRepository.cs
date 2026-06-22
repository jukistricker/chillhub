using chillhub.Contexts;
using chillhub.Entities.Media;
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
    }
}
