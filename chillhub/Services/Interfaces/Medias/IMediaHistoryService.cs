using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;

namespace chillhub.Services.Interfaces.Medias
{
    public interface IMediaHistoryService
    {
        Task AddRangeHistoryAsync(List<MediaHistorySaveRequest> histories);
        Task<IResult> GetMediaHistoriesAsync(MediaHistoryFilterRequest request);
    }
}
