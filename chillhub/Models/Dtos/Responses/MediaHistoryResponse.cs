namespace chillhub.Models.Dtos.Responses
{
    public class MediaHistoryResponse
    {
        public Guid Id { get; set; }
        public long Progress { get; set; }
        public Guid? UserId { get; set; }
        public Guid? MediaId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Thumbnail { get; set; }
        public long Duration { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }
    }
}
