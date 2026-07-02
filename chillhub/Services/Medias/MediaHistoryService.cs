using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using EFCore.BulkExtensions;

namespace chillhub.Services.Medias
{
    public class MediaHistoryService:IMediaHistoryService
    {
        private readonly IMediaHistoryRepository _mediaHistoryRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MediaHistoryService(
            IMediaHistoryRepository mediaHistoryRepository,
            IAuthRepository authRepository,
            IMediaRepository mediaRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _mediaHistoryRepository = mediaHistoryRepository;
            _authRepository = authRepository;
            _mediaRepository = mediaRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddRangeHistoryAsync(List<MediaHistorySaveRequest> histories)
        {
            if (histories == null || !histories.Any()) return;

            // 1. Lọc bỏ các phần tử có UserId hoặc MediaId là null ngay từ đầu
            var cleanHistories = histories
                .Where(h => h.UserId.HasValue && h.MediaId.HasValue)
                .ToList();

            if (!cleanHistories.Any()) return;

            // 2. Lấy danh sách ID duy nhất để validate dưới DB
            var userIds = cleanHistories.Select(h => h.UserId!.Value).Distinct().ToList();
            var mediaIds = cleanHistories.Select(h => h.MediaId!.Value).Distinct().ToList();

            var validUserIds = await _authRepository.GetValidUserIds(userIds);
            var validMediaIds = await _mediaRepository.GetValidMediaIds(mediaIds);

            // 3. Lọc dữ liệu hợp lệ từ DB
            var validHistories = cleanHistories.Where(h =>
                validUserIds.Contains(h.UserId!.Value) &&
                validMediaIds.Contains(h.MediaId!.Value)
            ).ToList();

            if (validHistories.Any())
            {
                var now = DateTimeOffset.UtcNow;

                // Nhóm các bản ghi trùng cặp (UserId, MediaId) gửi lên cùng lúc
                // Chỉ lấy bản ghi cuối cùng (bản ghi mới nhất) để xử lý tiếp
                var uniqueHistories = validHistories
                    .GroupBy(h => new { h.UserId, h.MediaId })
                    .Select(g => g.Last()) 
                    .ToList();

                var entitiesToSave = uniqueHistories.Select(h => new MediaHistory
                {
                    Id = h.Id ?? Guid.CreateVersion7(),

                    UserId = h.UserId,
                    MediaId = h.MediaId,
                    Progress = h.Progress,
                    CreatedAt = now,
                    CreatedBy = h.UserId,
                    UpdatedAt = now,
                    UpdatedBy = h.UserId
                }).ToList();

                await _mediaHistoryRepository.BulkInsertOrUpdateAsync(entitiesToSave, new BulkConfig
                {
                    // Chỉ định các cột dùng làm điều kiện để On Conflict (Match dữ liệu cũ)
                    UpdateByProperties = new List<string> { nameof(MediaHistory.UserId), nameof(MediaHistory.MediaId) },

                    // Loại trừ cột 'CreatedAt' và 'CreatedBy' không cho cập nhật lại khi bị trùng dữ liệu
                    PropertiesToExcludeOnUpdate = new List<string> { nameof(MediaHistory.CreatedAt), nameof(MediaHistory.CreatedBy) }
                });
            }
        }

        public async Task<IResult> GetMediaHistoriesAsync(MediaHistoryFilterRequest request)
        {
            Guid? userId = HttpContextUtil.GetUserId(_httpContextAccessor.HttpContext.User);
            if(userId == null) {
                return ResponseDto.Create(ResponseCatalog.Unauthorized);
            }
            request.UserId = userId;
            CursorResponse<MediaHistoryResponse> responses = await _mediaHistoryRepository.GetMediaHistoriesAsync(request);
            return ResponseDto.Create(ResponseCatalog.Success, "media.media_history.list", responses);
        }
    }
}
