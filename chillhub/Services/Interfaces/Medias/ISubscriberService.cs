using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;

namespace chillhub.Services.Interfaces.Medias
{
    public interface ISubscriberService
    {
        Task<bool> SubscribeBatchAsync(List<SubscribeBatchRequest> requests);
        Task<bool> UnsubscribeBatchAsync(List<UnsubscribeBatchRequest> requests);
        Task<IResult> GetSubscriberStatusAsync( Guid channelId);
        Task<IResult> GetChannelsAsync(SubscriberFilterRequest request);
    }
}
