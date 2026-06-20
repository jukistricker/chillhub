using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers
{
    [ApiController]
    [Route("media-history")]
    public class MediaHistoryController : ControllerBase
    {
        private readonly IMediaHistoryService _mediaHistoryService;

        public MediaHistoryController(IMediaHistoryService mediaHistoryService)
        {
            _mediaHistoryService = mediaHistoryService;
        }

        [HttpPost]
        public async Task<IResult> SaveMediaHistoryBatch([FromBody] List<MediaHistorySaveRequest> mediaHistories)
        {
            await _mediaHistoryService.AddRangeHistoryAsync(mediaHistories);
            return ResponseDto.Create(ResponseCatalog.Success);
        }

        [HttpGet]
        [Authorize]
        public async Task<IResult> GetMediaHistoriesAsync([FromQuery] MediaHistoryFilterRequest request)
        {
            return await _mediaHistoryService.GetMediaHistoriesAsync(request);
        }
    }
}
