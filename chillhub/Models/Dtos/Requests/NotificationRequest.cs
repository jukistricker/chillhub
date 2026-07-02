using chillhub.Models.Dtos.Requests.Search;

namespace chillhub.Models.Dtos.Requests
{
    public class NotificationFilterRequest : CursorRequest
    {
        public Guid UserId { get; set; }
    }

    public class MarkNotificationRequest
    {
        public Guid NotificationId { get; set; }
    }
}
