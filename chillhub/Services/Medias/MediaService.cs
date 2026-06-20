using chillhub.Entities.Media;
using chillhub.Mapping;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;

namespace chillhub.Services.Medias
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepo;
        private readonly IMediaCategoryRepository _mediaCategoryRepo;
        private readonly ICategoryRepository _categoryRepository;

        public MediaService(IMediaRepository mediaRepo, IMediaCategoryRepository mediaCategoryRepo, ICategoryRepository categoryRepository)
        {
            _mediaRepo = mediaRepo;
            _mediaCategoryRepo = mediaCategoryRepo;
            _categoryRepository = categoryRepository;
        }

        public async Task<IResult> CreateMediasBatchAsync(List<MediaCreateRequest> requests)
        {
            if (requests == null || !requests.Any())
                return ResponseDto.Create(ResponseCatalog.BadRequest, "media.batch_empty");

            var requestCategoryIds = requests
                .Where(r => r.CategoryIds != null)
                .SelectMany(r => r.CategoryIds)
                .Distinct()
                .ToList();

            var existingCategoryIds = await _categoryRepository.GetExistingIdsAsync(requestCategoryIds);
            var existingCategorySet = new HashSet<Guid>(existingCategoryIds);

            var newMedias = new List<Media>();
            var newMediaCategories = new List<MediaCategory>();

            foreach (var req in requests)
            {
                var mediaId = Guid.NewGuid();

                // Lọc ra các CategoryId hợp lệ
                var validCategoryIds = req.CategoryIds?
                    .Where(id => existingCategorySet.Contains(id))
                    .ToList() ?? new List<Guid>();

                // Xác định xem có category nào bị loại bỏ không
                bool hasInvalidCategory = req.CategoryIds != null &&
                                          validCategoryIds.Count < req.CategoryIds.Count;
                var media = new Media
                {
                    Id = mediaId,
                    Title = req.Title,
                    Description = req.Description,
                    Thumbnail = req.Thumbnail,
                    Duration = req.Duration,
                    UserId = req.UserId,
                    Type = req.Type,
                    FolderId= req.FolderId,
                    LikeCount = 0,
                    DislikeCount = 0,
                    OverallRating = null,
                    ViewCount=0,
                    MediaStatus = hasInvalidCategory ? MediaStatus.Fail : MediaStatus.Success,
                    CreatedBy = req.UserId
                };
                newMedias.Add(media);

                foreach (var categoryId in validCategoryIds)
                {
                    newMediaCategories.Add(new MediaCategory
                    {
                        MediaId = mediaId,
                        CategoryId = categoryId
                    });
                }
            }

            await _mediaRepo.AddRangeAsync(newMedias);

            if (newMediaCategories.Any())
            {
                await _mediaCategoryRepo.AddRangeAsync(newMediaCategories);
            }

            await _mediaRepo.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Created, "media.batch_processed", new
            {
                Total = newMedias.Count,
                SuccessCount = newMedias.Count(m => m.MediaStatus == MediaStatus.Success),
                FailedCount = newMedias.Count(m => m.MediaStatus == MediaStatus.Fail)
            });
        }
        public async Task<IResult> UpdateMediasBatchAsync(List<MediaUpdateRequest> requests)
        {
            if (requests == null || !requests.Any())
                return ResponseDto.Create(ResponseCatalog.BadRequest, "media.batch.empty");

            var mediaIds = requests.Select(x => x.Id).Distinct().ToList();

            var existingMedias = await _mediaRepo.GetByIdsAsync(mediaIds);

            var updatedMedias = new List<Media>();

            foreach (var req in requests)
            {
                var media = existingMedias.FirstOrDefault(x => x.Id == req.Id);
                if (media != null)
                {
                    media.Title = req.Title;
                    media.Description = req.Description;
                    media.Thumbnail = req.Thumbnail;

                    _mediaRepo.Update(media);
                    updatedMedias.Add(media);
                }
            }

            if (updatedMedias.Any())
            {
                await _mediaRepo.SaveChangesAsync();
            }

            return ResponseDto.Create(ResponseCatalog.Success, "media.batch.updated", updatedMedias);
        }

        public async Task<IResult> SearchMediasAsync(MediaFilterRequest request)
        {
            CursorResponse<Media> pagedResult = await _mediaRepo.GetMediasAsync(request);
            return ResponseDto.Create(ResponseCatalog.Success, "media.list", MediaMapping.ToResponseList(pagedResult));
        }
    }
}
