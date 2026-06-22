using chillhub.Entities.Media;
using chillhub.Mapping;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Models.Enums;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using EFCore.BulkExtensions;

namespace chillhub.Services.Medias
{
    public class MediaService : IMediaService
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly IMediaCategoryRepository _mediaCategoryRepo;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediaReactionRepository _mediaReactionRepository;

        public MediaService(IMediaRepository mediaRepo, 
            IMediaCategoryRepository mediaCategoryRepo, 
            ICategoryRepository categoryRepository, 
            IMediaReactionRepository mediaReactionRepository)
        {
            _mediaRepository = mediaRepo;
            _mediaCategoryRepo = mediaCategoryRepo;
            _categoryRepository = categoryRepository;
            _mediaReactionRepository = mediaReactionRepository;
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
                    CreatedBy = req.UserId,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
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

            await _mediaRepository.AddRangeAsync(newMedias);

            if (newMediaCategories.Any())
            {
                await _mediaCategoryRepo.AddRangeAsync(newMediaCategories);
            }

            await _mediaRepository.SaveChangesAsync();

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

            var existingMedias = await _mediaRepository.GetByIdsAsync(mediaIds);

            var updatedMedias = new List<Media>();

            foreach (var req in requests)
            {
                var media = existingMedias.FirstOrDefault(x => x.Id == req.Id);
                if (media != null)
                {
                    media.Title = req.Title;
                    media.Description = req.Description;
                    media.Thumbnail = req.Thumbnail;

                    _mediaRepository.Update(media);
                    updatedMedias.Add(media);
                }
            }

            if (updatedMedias.Any())
            {
                await _mediaRepository.SaveChangesAsync();
            }

            return ResponseDto.Create(ResponseCatalog.Success, "media.batch.updated", updatedMedias);
        }

        public async Task<IResult> SearchMediasAsync(MediaFilterRequest request)
        {
            CursorResponse<Media> pagedResult = await _mediaRepository.GetMediasAsync(request);
            return ResponseDto.Create(ResponseCatalog.Success, "media.list", MediaMapping.ToResponseList(pagedResult));
        }

        public async Task<IResult> BatchReactionAsync(List<MediaReactionRequest> requests)
        {
            if (requests == null || !requests.Any())
                return ResponseDto.Create(ResponseCatalog.BadRequest, "reaction.empty");

            // 1. Distinct MediaIDs để fetch dữ liệu 1 lần
            var mediaIds = requests.Select(r => r.MediaId).Distinct().ToList();
            var existingMedias = (await _mediaRepository.GetByIdsAsync(mediaIds)).ToDictionary(m => m.Id);

            // 2. Lọc bỏ các request vào Media không tồn tại
            var validRequests = requests.Where(r => existingMedias.ContainsKey(r.MediaId)).ToList();

            // 3. Xử lý trùng lặp (Chỉ lấy hành động cuối cùng của 1 user trên 1 media)
            var latestActions = validRequests
                .GroupBy(r => new { r.UserId, r.MediaId })
                .Select(g => g.Last())
                .ToList();

            var userIds = latestActions.Select(r => r.UserId).Distinct().ToList();
            var existingReactions = await _mediaReactionRepository.GetReactionsAsync(userIds, mediaIds);
            var existingReactionDict = existingReactions.ToDictionary(r => $"{r.UserId}_{r.MediaId}");

            var reactionsToUpsert = new List<MediaReaction>();
            var reactionsToDelete = new List<MediaReaction>();

            // Tập hợp các Media cần được cập nhật Counter (Dùng HashSet để nhận diện nhanh các Media bị thay đổi)
            var modifiedMedias = new HashSet<Media>();

            // 4. Duyệt qua từng hành động để tính toán trạng thái mới
            foreach (var req in latestActions)
            {
                var media = existingMedias[req.MediaId];
                existingReactionDict.TryGetValue($"{req.UserId}_{req.MediaId}", out var oldReaction);

                // Trường hợp 1: Có tương tác cũ -> Hoàn tác tương tác cũ (Trừ counter)
                if (oldReaction != null)
                {
                    if (oldReaction.ReactionType == ReactionType.Like) media.LikeCount--;
                    if (oldReaction.ReactionType == ReactionType.Dislike) media.DislikeCount--;

                    modifiedMedias.Add(media);
                }

                // Trường hợp 2: Hành động mới KHÔNG PHẢI là hủy tương tác (Discard)
                if (req.ReactionType != ReactionType.Discard)
                {
                    // Kiểm tra xem trạng thái mới có khác trạng thái cũ không, tránh cập nhật thừa
                    if (oldReaction == null || oldReaction.ReactionType != req.ReactionType)
                    {
                        reactionsToUpsert.Add(new MediaReaction
                        {
                            Id = oldReaction?.Id ?? Guid.CreateVersion7(), // Giữ Id cũ nếu là update, sinh mới nếu là insert
                            UserId = req.UserId,
                            MediaId = req.MediaId,
                            ReactionType = req.ReactionType
                        });

                        if (req.ReactionType == ReactionType.Like) media.LikeCount++;
                        if (req.ReactionType == ReactionType.Dislike) media.DislikeCount++;

                        modifiedMedias.Add(media);
                    }
                }
                // Trường hợp 3: Hành động mới LÀ Discard (và có tồn tại tương tác cũ) -> Đưa vào danh sách xóa
                else if (oldReaction != null)
                {
                    reactionsToDelete.Add(oldReaction);
                }
            }

            // Thao tác với bảng MediaReaction (Xóa các bản ghi Discard)
            if (reactionsToDelete.Any())
            {
                await _mediaReactionRepository.BulkDeleteAsync(reactionsToDelete);
            }

            // Thao tác với bảng MediaReaction (Thêm mới hoặc Cập nhật loại Reaction)
            if (reactionsToUpsert.Any())
            {
                await _mediaReactionRepository.BulkInsertOrUpdateAsync(reactionsToUpsert, new BulkConfig
                {
                    UpdateByProperties = new List<string> { nameof(MediaReaction.UserId), nameof(MediaReaction.MediaId) }
                });
            }

            // Thao tác với bảng Media (Cập nhật hàng loạt LikeCount/DislikeCount của các Media bị thay đổi)
            if (modifiedMedias.Any())
            {
                // Đồng bộ toàn bộ danh sách Media đã thay đổi Counter trong 1 single query duy nhất
                await _mediaRepository.BulkUpdateAsync(modifiedMedias.ToList());
            }

            return ResponseDto.Create(ResponseCatalog.Success, "reaction.batch_processed");
        }
    }
}
