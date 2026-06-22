using chillhub.Models.Enums;

namespace chillhub.Entities.Media
{
    public class MediaReaction
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid MediaId { get; set; }
        public ReactionType ReactionType { get; set; }
        public DateTimeOffset CreatedAt { get; set; } 
    }
}
