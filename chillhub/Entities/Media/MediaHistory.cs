using chillhub.Entities.Auth;

namespace chillhub.Entities.Media;

public class MediaHistory:BaseEntity
{
    public Guid? UserId { get; set; } 
    public Guid? MediaId { get; set; } 
    public long Progress { get; set; }
    public Media? Media { get; set; }
    public User? User { get; set; }
}