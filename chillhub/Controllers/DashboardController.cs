using chillhub.Attributes;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers
{
    [Route("dashboard")]
    [ApiController]
    public class DashboardController:ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        [RequiredPermission("admin.dashboard")]
        public async Task<IResult> GetDashboardsAsync([FromQuery] CursorRequest request)
        {
            return await _dashboardService.GetDashboardsAsync(request);
        }
    }
}
