using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Services.Interfaces.Medias
{
    public interface INotificationService
    {
        Task<IResult> GetUserNotificationsAsync(NotificationFilterRequest request);
        Task<IResult> MarkAsReadAsync(MarkNotificationRequest request);
        Task<IResult> MarkAllAsReadAsync();
    }
}
