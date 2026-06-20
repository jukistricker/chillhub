using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using Microsoft.AspNetCore.Http;

namespace chillhub.Services.Medias
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IResult> CreateCategoryAsync(CategorySaveRequest request)
        {
            var entity = request.ToEntity();
            entity.Id = Guid.Empty; 

            await _categoryRepo.AddAsync(entity);
            await _categoryRepo.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Created, "media.category.created", entity);
        }

        public async Task<IResult> UpdateCategoryAsync(CategorySaveRequest request)
        {
            if (!request.Id.HasValue || request.Id == Guid.Empty)
                return ResponseDto.Create(ResponseCatalog.BadRequest, "media.category.id_required");

            var entity = request.ToEntity();

            _categoryRepo.Update(entity);
            await _categoryRepo.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Success, "media.category.updated", entity);
        }

        public async Task<IResult> SearchCategoriesAsync(CategoryFilterRequest request)
        {
            var pagedResult = await _categoryRepo.GetCategoriesAsync(request);

            return ResponseDto.Create(ResponseCatalog.Success, "media.category.list", pagedResult);
        }
    }
}