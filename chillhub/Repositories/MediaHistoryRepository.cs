using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class MediaHistoryRepository : Repository<MediaHistory>, IMediaHistoryRepository
    {
        public MediaHistoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CursorResponse<MediaHistoryResponse>> GetMediaHistoriesAsync(MediaHistoryFilterRequest request)
        {
            var query = GetQueryable().AsNoTracking();

            if (request.Id.HasValue) query = query.Where(x => x.Id == request.Id);
            if (request.UserId.HasValue) query = query.Where(x => x.UserId == request.UserId);

            var projection = query.Select(h => new MediaHistoryResponse
            {
                Id = h.Id,
                Progress = h.Progress,
                Title = h.Media != null ? h.Media.Title : "Unknown",
                Thumbnail = h.Media.Thumbnail !=null ? h.Media.Thumbnail : "Unknown",
                Duration = h.Media.Duration,
                Username = h.User != null ? h.User.Username : "Unknown",
                FullName = h.User != null ? h.User.FullName : "Unknown",
                UserId = h.UserId,
                MediaId = h.MediaId,
                AvatarUrl = h.User.AvatarUrl
            });

            return await GetByCursorAsync(projection, request, h => h.Id);
        }
    }
}
