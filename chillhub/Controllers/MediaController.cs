using chillhub.Models.Dtos.Requests;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers
{
    [Route("media")]
    [ApiController]
    public class MediasController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediasController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("batch")]
        public async Task<IResult> CreateBatchAsync([FromBody] List<MediaCreateRequest> requests)
        {
            return await _mediaService.CreateMediasBatchAsync(requests);
        }

        [HttpPut("batch")]
        public async Task<IResult> UpdateBatchAsync([FromBody] List<MediaUpdateRequest> requests)
        {
            return await _mediaService.UpdateMediasBatchAsync(requests);
        }

        [HttpGet]
        public async Task<IResult> SearchAsync([FromQuery] MediaFilterRequest request)
        {
            return await _mediaService.SearchMediasAsync(request);
        }

        [HttpGet("recommend/{mediaId}")]
        public async Task<IResult> GetRecommentMedia(Guid mediaId)
        {
            return await _mediaService.GetRecommendMediasAsync(mediaId);
        }


        [HttpPost("reaction-batch")]
        public async Task<IResult> BatchReaction([FromBody] List<MediaReactionRequest> requests)
        {
            return await _mediaService.BatchReactionAsync(requests);
        }

        [HttpGet("reaction")]
        [Authorize]
        public async Task<IResult> SearchAsync([FromQuery] MediaReactionFilterRequest request)
        {
            return await _mediaService.GetReactionCursorAsync(request);
        }

    }
}