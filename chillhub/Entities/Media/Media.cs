using chillhub.Entities.Auth;
using chillhub.Models.Enums;

namespace chillhub.Entities.Media;

public class Media:BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public long Duration { get; set; }
    public Guid UserId { get; set; }
    public MediaType Type { get; set; }
    public long LikeCount { get; set; }
    public long DislikeCount { get; set; }
    public float? OverallRating { get; set; }
    public MediaStatus MediaStatus { get; set; } = MediaStatus.Draft;
    public long ViewCount { get; set; }
    public Guid FolderId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<MediaCategory> MediaCategories { get; set; }
}
