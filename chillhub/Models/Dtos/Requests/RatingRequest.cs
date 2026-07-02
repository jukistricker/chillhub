namespace chillhub.Models.Dtos.Requests
{
    public class MovieRatingCreateRequest
    {
        public Guid MovieId { get; set; }
        public int Rating { get; set; }
    }
    public class MovieRatingUpdateRequest
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
    }
}