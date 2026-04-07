using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Responses;

public class UserSession
{
    public Guid UserId { get; set; }
    public string Username { get; set; } = null!;
    public HashSet<Guid> RoleIds { get; set; } = new();
    public HashSet<string> Permissions { get; set; } = new();
    public LanguageEnum Lang { get; set; }
    public DateTime IssuedAt { get; set; }
    public DateTime ExpiresAt { get; set; }
}
