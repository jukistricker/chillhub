using chillhub.Models.Dtos.Requests.Search;
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

    public class MediaReactionFilterRequest:CursorRequest
    {
        public Guid UserId { get; set; }
        public Guid MediaId { get; set; }
    }
}
