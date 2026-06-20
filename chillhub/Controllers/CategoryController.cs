using chillhub.Attributes;
using chillhub.Models.Dtos.Requests;
using chillhub.Services.Interfaces.Medias;
using Microsoft.AspNetCore.Mvc;

namespace chillhub.Controllers;

[Route("category")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [RequiredPermission("media.create_category")]
    public async Task<IResult> CreateAsync([FromBody] CategorySaveRequest request)
    {
        return await _categoryService.CreateCategoryAsync(request);
    }

    [HttpPut("{id:guid}")]
    [RequiredPermission("media.update_category")]
    public async Task<IResult> UpdateAsync(Guid id, [FromBody] CategorySaveRequest request)
    {
        // Đảm bảo Id từ URL được gán vào request để service xử lý chính xác
        request.Id = id;
        return await _categoryService.UpdateCategoryAsync(request);
    }

    [HttpGet]
    public async Task<IResult> SearchAsync([FromQuery] CategoryFilterRequest request)
    {
        return await _categoryService.SearchCategoriesAsync(request);
    }
}