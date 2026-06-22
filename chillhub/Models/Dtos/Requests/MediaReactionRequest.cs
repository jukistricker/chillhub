using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Requests
{
    public class MediaReactionRequest
    {
        public Guid UserId { get; set; }
        public Guid MediaId { get; set; }
        public ReactionType ReactionType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
