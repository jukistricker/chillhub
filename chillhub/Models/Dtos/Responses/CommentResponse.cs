namespace chillhub.Models.Dtos.Responses
{
    public class CommentResponse
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public Guid EntityId { get; set; }
        public Guid? ReferenceCommentId { get; set; }
        public bool HasChildren { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public string? UserFullName { get; set; }
        public string? UserAvatarUrl { get; set; }
    }
}
