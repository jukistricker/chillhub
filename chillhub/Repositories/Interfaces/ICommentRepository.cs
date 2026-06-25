using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Guid>> GetExistingIdsAsync(List<Guid> ids);
        Task<List<Comment>> GetByIdsAsync(IEnumerable<Guid> ids);
        Task<CursorResponse<Comment>> GetCommentsAsync(CommentFilterRequest request);
    }
}
