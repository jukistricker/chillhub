using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Medias;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;

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

            // 2. Lấy danh sách ID duy nhất
            var userIds = cleanHistories.Select(h => h.UserId!.Value).Distinct().ToList();
            var mediaIds = cleanHistories.Select(h => h.MediaId!.Value).Distinct().ToList();

            var validUserIds = await _authRepository.GetValidUserIds(userIds);
            var validMediaIds = await _mediaRepository.GetValidMediaIds(mediaIds);

            // 3. Lọc dữ liệu bằng HashSet.Contains() 
            var validHistories = cleanHistories.Where(h =>
                validUserIds.Contains(h.UserId!.Value) &&
                validMediaIds.Contains(h.MediaId!.Value)
            ).ToList();

            if (validHistories.Any())
            {
                // 4. CHUYỂN ĐỔI (MAP) TỪ DTO SANG ENTITY
                var entitiesToSave = validHistories.Select(h => new MediaHistory
                {
                    Id = h.Id ?? Guid.CreateVersion7(),

                    UserId = h.UserId,
                    MediaId = h.MediaId,
                    Progress = h.Progress,
                    CreatedAt = DateTime.UtcNow,
                    CreatedBy = h.UserId,
                    UpdatedBy = h.UserId,
                    UpdatedAt = DateTime.UtcNow,
                }).ToList();

                // 5. Truyền danh sách Entity vào Repository
                await _mediaHistoryRepository.AddRangeAsync(entitiesToSave);
                await _mediaHistoryRepository.SaveChangesAsync();
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
