namespace chillhub.Models.Dtos.Requests
{
    public class SubscribeBatchRequest
    {
        public Guid SubscriberId { get; set; }
        public Guid ChannelId { get; set; }
        public bool IsNotice { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }

    public class UnsubscribeBatchRequest
    {
        public Guid SubscriberId { get; set; }
        public Guid ChannelId { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
