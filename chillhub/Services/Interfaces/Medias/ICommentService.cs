using chillhub.Models.Dtos.Requests;

namespace chillhub.Services.Interfaces.Medias
{
    public interface ICommentService
    {
        Task<IResult> CreateCommentsBatchAsync(List<CommentCreateRequest> requests);
        Task<IResult> UpdateCommentsBatchAsync(List<CommentUpdateRequest> requests);
        Task<IResult> SearchCommentsAsync(CommentFilterRequest request);
    }
}
