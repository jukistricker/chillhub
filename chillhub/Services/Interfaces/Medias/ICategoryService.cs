using chillhub.Models.Dtos.Requests;
using Microsoft.AspNetCore.Http;

namespace chillhub.Services.Interfaces.Medias;

public interface ICategoryService
{
    Task<IResult> CreateCategoryAsync(CategorySaveRequest request);
    Task<IResult> UpdateCategoryAsync(CategorySaveRequest request);
    Task<IResult> SearchCategoriesAsync(CategoryFilterRequest request);
}