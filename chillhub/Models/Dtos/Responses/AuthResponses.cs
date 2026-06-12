using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Responses;

public record UserFullInfo(
    User User, 
    HashSet<Guid> RoleIds, 
    HashSet<string> Permissions
    );
    
public class UserResponse:BaseResponse
{
    public string Username { get; set; } = null!;
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public string? AvatarUrl { get; set; }
    public string? Provider { get; set; }        // "google", "local", "github"...
    public string? ExternalId { get; set; }      // ID từ Provider gửi về
    public LanguageEnum Lang { get; set; }
    public List<RoleResponse> Roles { get; set; }
} 