using chillhub.Models.Dtos.Requests;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace chillhub.Controllers.Medias;

[Authorize]
[ApiController]
[Route("notifications")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IResult> GetNotifications([FromQuery]NotificationFilterRequest request)
    {
        return await _notificationService.GetUserNotificationsAsync(request);
        
    }

    [HttpPatch("{id}/read")]
    public async Task<IResult> MarkAsRead(MarkNotificationRequest request)
    {
        return await _notificationService.MarkAsReadAsync(request);
    }

    [HttpPatch("read-all")]
    public async Task<IActionResult> MarkAllAsRead()
    {
        _notificationService.MarkAllAsReadAsync();
        return NoContent();
        
    }
}