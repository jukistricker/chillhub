using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        Task<Subscriber?> GetAsync(Guid subscriberId, Guid channelId); 
        Task<List<Guid>> GetSubscriberIdsByChannelIdAsync(Guid channelId);
        Task<CursorResponse<Subscriber>> GetSubscribersAsync(SubscriberFilterRequest request);
    }
}
