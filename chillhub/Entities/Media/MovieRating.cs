namespace chillhub.Entities.Media;

public class MovieRating:BaseEntity
{
    public Guid MovieId { get; set; }
    public int Rating { get; set; } 
    public Guid UserId { get; set; }
    public Media? Movie { get; set; }
}