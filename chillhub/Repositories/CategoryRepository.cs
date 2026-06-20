using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CursorResponse<Category>> GetCategoriesAsync(CategoryFilterRequest request)
        {
            var query = GetQueryable();

            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id);

            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(x => x.Name.Contains(request.Name));

            return await GetByCursorAsync(query, request, u => u.Id);
        }

        public async Task<List<Guid>> GetExistingIdsAsync(List<Guid> categoryIds)
        {
            if (categoryIds == null || !categoryIds.Any())
                return new List<Guid>();

            var uniqueIds = categoryIds.Distinct();

            return await _dbSet
                .Where(c => uniqueIds.Contains(c.Id))
                .Select(c => c.Id)
                .ToListAsync();
        }
    }
}