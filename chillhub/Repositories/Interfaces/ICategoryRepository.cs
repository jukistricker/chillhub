using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;

namespace chillhub.Repositories.Interfaces;

public interface ICategoryRepository : IRepository<Category>
{
    Task<CursorResponse<Category>> GetCategoriesAsync(CategoryFilterRequest request);
}