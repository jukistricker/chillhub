namespace chillhub.Entities.Media;

public class Post:BaseEntity
{
    public string Description { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
}
