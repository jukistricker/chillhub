//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
//using System.Security.Claims;
//using chillhub.Services.Interfaces.Medias;
//using chillhub.Models.Dtos.Requests;
//using chillhub.Models.Dtos.Responses;

//namespace chillhub.Controllers
//{
//    [Authorize] // Bắt buộc đăng nhập để sử dụng các API này
//    [ApiController]
//    [Route("api/channels/{channelId}/subscribers")]
//    public class SubscriberController : ControllerBase
//    {
//        private readonly ISubscriberService _subscriberService;

//        public SubscriberController(ISubscriberService subscriberService)
//        {
//            _subscriberService = subscriberService;
//        }

//        /// <summary>
//        /// Lấy trạng thái đăng ký của User hiện tại đối với Channel
//        /// </summary>
//        [HttpGet("status")]
//        public async Task<ActionResult<SubscriberResponse>> GetStatus(Guid channelId)
//        {
//            var subscriberId = GetCurrentUserId();

//            // Ngăn tự check trạng thái của chính mình (Tùy bối cảnh dự án của bạn)
//            if (subscriberId == channelId)
//            {
//                return BadRequest("You cannot check subscription status on your own channel.");
//            }

//            var result = await _subscriberService.GetSubscriberStatusAsync(subscriberId, channelId);
//            return Ok(result);
//        }

//        /// <summary>
//        /// Đăng ký theo dõi hoặc cập nhật trạng thái nhận thông báo (IsNotice)
//        /// </summary>
//        [HttpPost]
//        public async Task<IActionResult> Subscribe(Guid channelId, [FromBody] SubscribeRequest request)
//        {
//            var subscriberId = GetCurrentUserId();

//            if (subscriberId == channelId)
//            {
//                return BadRequest("You cannot subscribe to your own channel.");
//            }

//            var success = await _subscriberService.SubscribeAsync(subscriberId, channelId, request.IsNotice);
//            if (!success) return BadRequest("Failed to process subscription.");

//            return Ok(new { message = "Subscribed successfully or notification settings updated." });
//        }

//        /// <summary>
//        /// Hủy đăng ký theo dõi kênh
//        /// </summary>
//        [HttpDelete]
//        public async Task<IActionResult> Unsubscribe(Guid channelId)
//        {
//            var subscriberId = GetCurrentUserId();

//            var success = await _subscriberService.UnsubscribeAsync(subscriberId, channelId);
//            if (!success) return BadRequest("Failed to unsubscribe.");

//            return Ok(new { message = "Unsubscribed successfully." });
//        }

//        /// <summary>
//        /// Helper lấy UserId từ JWT Token của người dùng đang đăng nhập
//        /// </summary>
//        private Guid GetCurrentUserId()
//        {
//            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

//            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
//            {
//                throw new UnauthorizedAccessException("User context is missing or invalid.");
//            }

//            return userId;
//        }
//    }
//}