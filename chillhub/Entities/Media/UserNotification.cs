namespace chillhub.Entities.Media
{
    public class UserNotification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }       
        public Guid MediaId { get; set; }        
        public string Title { get; set; } = string.Empty; //denormalization
        public string Thumbnail { get; set; } = string.Empty;
        public bool IsRead { get; set; } = false;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
