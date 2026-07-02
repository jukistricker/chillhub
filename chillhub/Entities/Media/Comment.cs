using chillhub.Entities.Auth;

namespace chillhub.Entities.Media;

public class Comment: BaseEntity
{
    public string? Description { get; set; }
    public Guid UserId { get; set; }
    public Guid EntityId { get; set; }
    public Guid? ReferenceCommentId { get; set; }
    public bool HasChildren { get; set; } = false;
    public virtual User User { get; set; } = null!;
}
