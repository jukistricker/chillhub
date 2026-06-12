using chillhub.Models.Dtos.Requests;
using chillhub.Services.Interfaces;
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
    public async Task<IResult> CreateAsync([FromBody] CategorySaveRequest request)
    {
        return await _categoryService.CreateCategoryAsync(request);
    }

    [HttpPut("{id:guid}")]
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