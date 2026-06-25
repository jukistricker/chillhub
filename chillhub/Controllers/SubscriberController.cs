using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers.Medias;

[ApiController]
[Route("subscribers")]
public class SubscriberController : ControllerBase
{
    private readonly ISubscriberService _subscriberService;

    public SubscriberController(ISubscriberService subscriberService)
    {
        _subscriberService = subscriberService;
    }

    [HttpPost("batch-subscribe")]
    public async Task<IActionResult> BatchSubscribe([FromBody] List<SubscribeBatchRequest> requests)
    {
        var result = await _subscriberService.SubscribeBatchAsync(requests);

        if (!result)
        {
            return BadRequest(ResponseDto.Create(ResponseCatalog.BadRequest, "subscriber.batch_subscribe_failed"));
        }

        return Ok(ResponseDto.Create(ResponseCatalog.Success, "subscriber.batch_subscribe_success"));
    }

    [HttpPost("batch-unsubscribe")]
    public async Task<IActionResult> BatchUnsubscribe([FromBody] List<UnsubscribeBatchRequest> requests)
    {
        var result = await _subscriberService.UnsubscribeBatchAsync(requests);

        if (!result)
        {
            return BadRequest(ResponseDto.Create(ResponseCatalog.BadRequest, "subscriber.batch_unsubscribe_failed"));
        }

        return Ok(ResponseDto.Create(ResponseCatalog.Success, "subscriber.batch_unsubscribe_success"));
    }

    [Authorize]
    [HttpGet("status/{channelId}")]
    public async Task<IResult> GetSubscriberStatus(Guid channelId)
    {
        return await _subscriberService.GetSubscriberStatusAsync( channelId);

    }

    [Authorize]
    [HttpGet]
    public async Task<IResult> GetChannelsAsync([FromQuery]SubscriberFilterRequest request)
    {
        return await _subscriberService.GetChannelsAsync(request);

    }
}