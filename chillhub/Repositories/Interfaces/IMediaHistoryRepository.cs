using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface IMediaHistoryRepository : IRepository<MediaHistory>
    {
        Task<CursorResponse<MediaHistoryResponse>> GetMediaHistoriesAsync(MediaHistoryFilterRequest request);
    }
}
