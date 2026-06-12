using chillhub.Entities;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface IDashboardRepository : IRepository<Dashboard>
    {
        Task<CursorResponse<Dashboard>> GetDashboardsAsync(CursorRequest request);
    }
}
