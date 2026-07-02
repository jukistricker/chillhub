using chillhub.Models.Enums;

namespace chillhub.Models.Dtos.Responses;

public class UserSession
{
    public Guid UserId { get; set; }
    public string  FullName { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; }
    public HashSet<Guid> RoleIds { get; set; } = new();
    public HashSet<string> Permissions { get; set; } = new();
    public LanguageEnum Lang { get; set; }
    public DateTimeOffset IssuedAt { get; set; }
    public DateTimeOffset ExpiresAt { get; set; }
}
