using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Responses
{
    public class MediaResponse:BaseResponse
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Thumbnail { get; set; }
        public long Duration { get; set; }
        public long ViewCount { get; set; }
        public Guid UserId { get; set; }
        public MediaType Type { get; set; }
        public long LikeCount { get; set; }
        public long DislikeCount { get; set; }
        public float? OverallRating { get; set; }
        public Guid FolderId { get; set; }
        public MediaStatus MediaStatus { get; set; }
        public UserDto User { get; set; }
    }
}
