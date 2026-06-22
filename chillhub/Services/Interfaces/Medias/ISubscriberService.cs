using chillhub.Entities.Media;
using chillhub.Models.Dtos.Responses;

namespace chillhub.Services.Interfaces.Medias
{
    public interface ISubscriberService
    {
        Task<bool> SubscribeAsync(Guid subscriberId, Guid channelId, bool isNotice = true);
        Task<bool> UnsubscribeAsync(Guid subscriberId, Guid channelId);
        Task<SubscriberResponse> GetSubscriberStatusAsync(Guid subscriberId, Guid channelId);
    }
}
