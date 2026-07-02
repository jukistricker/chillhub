using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        Task<CursorResponse<UserNotification>> GetUserNotificationsAsync(NotificationFilterRequest request);
        Task<UserNotification> GetByUserIdAsync(Guid notificationId, Guid userId);
        Task UpdateAllByUserIdAsync(Guid userId);
    }
}
