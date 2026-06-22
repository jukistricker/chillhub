using chillhub.Entities.Auth;
using chillhub.Entities.Media;

namespace chillhub.Repositories.Interfaces
{
    public interface IMediaReactionRepository : IRepository<MediaReaction>
    {
        Task<List<MediaReaction>> GetReactionsAsync(List<Guid> userIds, List<Guid> mediaIds);
    }
}
