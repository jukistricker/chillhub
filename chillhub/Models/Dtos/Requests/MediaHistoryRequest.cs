using chillhub.Models.Dtos.Requests.Search;

namespace chillhub.Models.Dtos.Requests
{
    public class MediaHistorySaveRequest
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? MediaId { get; set; }
        public long Progress { get; set; }
    }
    public class MediaHistoryFilterRequest : CursorRequest
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
    }
}
