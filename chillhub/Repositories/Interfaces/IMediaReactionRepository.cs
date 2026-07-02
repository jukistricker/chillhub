using chillhub.Entities.Auth;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface IMediaReactionRepository : IRepository<MediaReaction>
    {
        Task<List<MediaReaction>> GetReactionsAsync(List<Guid> userIds, List<Guid> mediaIds);
        Task<CursorResponse<MediaReaction>> GetCursorReactionsAsync(MediaReactionFilterRequest request);
    }
}
