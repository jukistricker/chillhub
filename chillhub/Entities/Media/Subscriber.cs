namespace chillhub.Entities.Media
{
    public class Subscriber
    {
        public Guid Id { get; set; }
        public Guid SubscriberId { get; set; }
        public Guid ChannelId { get; set; }
        public bool IsNotice { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; }
    }
}
