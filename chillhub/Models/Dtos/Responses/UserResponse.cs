namespace chillhub.Models.Dtos.Responses
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public String Username { get; set; }
        public String Email { get; set; }
        public string? FullName { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
