namespace chillhub.Entities.Media;

public class MediaHistory:BaseEntity
{
    public Guid UserId { get; set; } 
    public Guid MediaId { get; set; } 
    public int Progress { get; set; }

    public Media? Media { get; set; }
}