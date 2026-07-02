using chillhub.Entities.Media;
using chillhub.Models.Enums;

namespace chillhub.Entities.Auth
{
    public class User:BaseEntity
    {
        public string? Username { get; set; }
        public string? Password { get; set; }        // Có thể null (Social Login)
        public string? Email { get; set; }           // Có thể null
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Provider { get; set; }        // "google", "local", "github"...
        public string? ExternalId { get; set; }      // ID từ Provider gửi về
        public LanguageEnum Lang { get; set; }
        public bool IsFirstLogin { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual 
            ICollection<Media.Media> Medias { get; set; }
    }

}
