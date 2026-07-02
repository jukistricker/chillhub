using chillhub.Models.Dtos.Requests.Search;

namespace chillhub.Services.Interfaces.Medias
{
    public interface IDashboardService
    {
        Task<IResult> GetDashboardsAsync(CursorRequest request);
    }
}
