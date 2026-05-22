namespace chillhub.Entities.Media;

public class Comment: BaseEntity
{
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public long LikeCount { get; set; }
    public long DislikeCount { get; set; }
    public Guid ReferenceCommentId { get; set; }
}
