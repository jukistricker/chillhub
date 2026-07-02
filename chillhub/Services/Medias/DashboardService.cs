using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;

namespace chillhub.Services.Medias
{
    public class DashboardService: IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;

        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public async Task<IResult> GetDashboardsAsync(CursorRequest request)
        {
            var pagedResult = await _dashboardRepository.GetDashboardsAsync(request);

            return ResponseDto.Create(ResponseCatalog.Success, "dashboard.list", pagedResult);
        }
    }
}
