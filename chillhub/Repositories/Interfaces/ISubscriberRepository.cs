using chillhub.Entities.Media;

namespace chillhub.Repositories.Interfaces
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        Task<Subscriber?> GetAsync(Guid subscriberId, Guid channelId); 
        Task<List<Guid>> GetSubscriberIdsByChannelIdAsync(Guid channelId);
    }
}
