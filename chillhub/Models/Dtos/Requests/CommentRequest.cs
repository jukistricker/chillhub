using chillhub.Models.Dtos.Requests.Search;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace chillhub.Models.Dtos.Requests
{
    public class CommentCreateRequest
    {
        public string? Description { get; set; }

        public Guid UserId { get; set; }

        /// <summary>
        /// ID của Media được comment (Map vào EntityId của Comment)
        /// </summary>
        public Guid EntityId { get; set; }

        /// <summary>
        /// ID của comment cha nếu đây là một phản hồi (Reply). Để null nếu là comment gốc.
        /// </summary>
        public Guid? ReferenceCommentId { get; set; }
    }

    public class CommentUpdateRequest
    {
        public Guid Id { get; set; }

        public string? Description { get; set; }
    }

    public class CommentFilterRequest : CursorRequest
    {
        [Required(ErrorMessage = "media.comment.entity_id_required")]
        public Guid EntityId { get; set; }
        public Guid ReferenceCommentId { get; set; } = Guid.Empty;
    }
}