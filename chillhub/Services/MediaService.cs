using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces;

namespace chillhub.Services
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepo;
        private readonly IMediaCategoryRepository _mediaCategoryRepo;

        public MediaService(IMediaRepository mediaRepo, IMediaCategoryRepository mediaCategoryRepo)
        {
            _mediaRepo = mediaRepo;
            _mediaCategoryRepo = mediaCategoryRepo;
        }

        public async Task<IResult> CreateMediasBatchAsync(List<MediaCreateRequest> requests)
        {
            if (requests == null || !requests.Any())
                return ResponseDto.Create(ResponseCatalog.BadRequest, "media.batch_empty");

            var newMedias = new List<Media>();
            var newMediaCategories = new List<MediaCategory>();

            foreach (var req in requests)
            {
                var mediaId = Guid.NewGuid();

                var media = new Media
                {
                    Id = mediaId,
                    Title = req.Title,
                    Description = req.Description,
                    Thumbnail = req.Thumbnail,
                    Duration = req.Duration,
                    UserId = req.UserId,
                    Type = req.Type,
                    LikeCount = 0, 
                    DislikeCount = 0,
                    OverallRating = null,

                };
                newMedias.Add(media);

                if (req.CategoryIds != null && req.CategoryIds.Any())
                {
                    foreach (var categoryId in req.CategoryIds)
                    {
                        newMediaCategories.Add(new MediaCategory
                        {
                            MediaId = mediaId,
                            CategoryId = categoryId
                        });
                    }
                }
            }

            await _mediaRepo.AddRangeAsync(newMedias);

            if (newMediaCategories.Any())
            {
                await _mediaCategoryRepo.AddRangeAsync(newMediaCategories);
            }

            await _mediaRepo.SaveChangesAsync();

            return ResponseDto.Create(ResponseCatalog.Created, "media.batch.created", newMedias);
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
            var pagedResult = await _mediaRepo.GetMediasAsync(request);
            return ResponseDto.Create(ResponseCatalog.Success, "media.list", pagedResult);
        }
    }
}
