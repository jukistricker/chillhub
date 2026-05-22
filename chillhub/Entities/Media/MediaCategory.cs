namespace chillhub.Entities.Media
{
    public class MediaCategory
    {
        public Guid MediaId { get; set; }
        public Guid CategoryId { get; set; }

        public Media? Media { get; set; }
        public Category? Category { get; set; }
    }
}
