using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Guid>> GetExistingIdsAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<Guid>();

            return await _dbSet
                .AsNoTracking()
                .Where(c => ids.Contains(c.Id))
                .Select(c => c.Id)
                .ToListAsync();
        }

        public async Task<List<Comment>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<CursorResponse<Comment>> GetCommentsAsync(CommentFilterRequest request)
        {
            var query = GetQueryable().AsNoTracking();

            query = query.Where(x => x.EntityId == request.EntityId);
            Guid? filterReferenceId = (request.ReferenceCommentId == Guid.Empty) ? null : request.ReferenceCommentId;

            query = query.Where(x => x.ReferenceCommentId == filterReferenceId);


            query = query.Include(x => x.User);

            return await GetByCursorAsync(query, request, u => u.Id);
        }
    }
}
