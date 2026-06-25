using chillhub.Entities.Media;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Mapping
{
    public static class CommentMapping
    {
        public static CommentResponse? ToResponse(this Comment? entity)
        {
            if (entity == null) return null;

            return new CommentResponse
            {
                Id = entity.Id,
                Description = entity.Description,
                EntityId = entity.EntityId,
                ReferenceCommentId = entity.ReferenceCommentId,
                HasChildren = entity.HasChildren,
                CreatedAt = entity.CreatedAt,

                UserId = entity.UserId,
                UserFullName = entity.User?.FullName ?? "Chillhub User",
                UserAvatarUrl = entity.User?.AvatarUrl
            };
        }

        /// <summary>
        /// Map một danh sách (List/IEnumerable) các Comments
        /// </summary>
        public static List<CommentResponse> ToResponseList(this IEnumerable<Comment> entities)
        {
            if (entities == null) return new List<CommentResponse>();

            return entities
                .Select(e => e.ToResponse())
                .Where(res => res != null)
                .Cast<CommentResponse>()
                .ToList();
        }

        /// <summary>
        /// Map toàn bộ cấu trúc phân trang CursorResponse từ Entity sang DTO
        /// </summary>
        public static CursorResponse<CommentResponse> ToCursorResponse(this CursorResponse<Comment> pagedResult)
        {
            if (pagedResult == null) return new CursorResponse<CommentResponse>();

            return new CursorResponse<CommentResponse>
            {
                NextCursor = pagedResult.NextCursor,
                Items = pagedResult.Items.ToResponseList(),
                HasNextPage = pagedResult.HasNextPage
            };
        }
    }
}