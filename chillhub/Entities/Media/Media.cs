namespace chillhub.Entities.Media;

public class Media:BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public int Duration { get; set; }
    public Guid UserId { get; set; }
    public int Type { get; set; }
    public long LikeCount { get; set; }
    public long DislikeCount { get; set; }
    public float? OverallRating { get; set; }
}
