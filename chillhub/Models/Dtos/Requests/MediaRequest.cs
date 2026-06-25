using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Requests;

public class MediaCreateRequest
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
    public int Duration { get; set; }
    public Guid FolderId { get; set; }
    public Guid UserId { get; set; }
    public MediaType Type { get; set; }
    // Nhận vào mảng ID của Category
    public List<Guid> CategoryIds { get; set; } = new List<Guid>();
}

public class MediaUpdateRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Thumbnail { get; set; }
}

public class MediaFilterRequest : CursorRequest
{
    public Guid? Id { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid? UserId { get; set; }
    public MediaType? Type { get; set; }
}

public class MediaRecommendationDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Thumbnail { get; set; }
    public long Duration { get; set; }
    public MediaType Type { get; set; } // Hoặc kiểu Enum MediaType của bạn
    public UserDto User { get; set; }
}