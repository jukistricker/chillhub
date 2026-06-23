using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Services.Medias;

public class NotificationService : INotificationService
{
    private readonly IUserNotificationRepository _userNotificationRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public NotificationService(IUserNotificationRepository userNotificationRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _userNotificationRepository = userNotificationRepository;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<IResult> GetUserNotificationsAsync(NotificationFilterRequest request)
    {
        Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
        request.UserId = userId.Value;
        CursorResponse<UserNotification> response =await _userNotificationRepository.GetUserNotificationsAsync(request);

        return ResponseDto.Create(ResponseCatalog.Success, "notification.fetch_success", response);
    }

    public async Task<IResult> MarkAsReadAsync(MarkNotificationRequest request)
    {
        Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
        var notification = await _userNotificationRepository.GetByUserIdAsync(request.NotificationId, userId.Value);

        if (notification == null)
        {
            return ResponseDto.Create(ResponseCatalog.NotFound, "notification.not_found");
        }

        if (!notification.IsRead)
        {
            notification.IsRead = true;
            await _userNotificationRepository.SaveChangesAsync();
        }

        return ResponseDto.Create(ResponseCatalog.Success, "notification.marked_as_read");
    }

    public async Task<IResult> MarkAllAsReadAsync()
    {
        Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
        await _userNotificationRepository.UpdateAllByUserIdAsync(userId.Value);

        return ResponseDto.Create(ResponseCatalog.Success, "notification.mark_all_success");
    }
}