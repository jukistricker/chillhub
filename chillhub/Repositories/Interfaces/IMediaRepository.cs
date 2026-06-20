using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface IMediaRepository : IRepository<Media>
    {
        Task<CursorResponse<Media>> GetMediasAsync(MediaFilterRequest request);
        Task<List<Media>> GetByIdsAsync(IEnumerable<Guid> ids);
        Task<HashSet<Guid>> GetValidMediaIds(IEnumerable<Guid> mediaIds);
    }
}