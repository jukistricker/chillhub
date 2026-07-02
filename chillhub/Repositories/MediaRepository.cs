using chillhub.Contexts;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class MediaRepository : Repository<Media>, IMediaRepository
    {
        private readonly AppDbContext _db;
        public MediaRepository(AppDbContext context) : base(context)
        {
            _db = context;
        }

        public async Task<CursorResponse<Media>> GetMediasAsync(MediaFilterRequest request)
        {
            var query = GetQueryable().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
                query = query.Where(x => x.Title.Contains(request.Search));

            if (request.UserId.HasValue)
                query = query.Where(x => x.UserId == request.UserId);
            if (request.Id.HasValue)
                query = query.Where(x => x.Id == request.Id);

            if (request.Type.HasValue)
                query = query.Where(x => x.Type == request.Type);

            query = query.Include(x => x.User)
                .Include(x => x.MediaCategories);

            return await GetByCursorAsync(query, request, u => u.Id);
        }

        public async Task<List<Media>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await _dbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<HashSet<Guid>> GetValidMediaIds(IEnumerable<Guid> mediaIds)
        {
            List<Guid> list = await _dbSet
                .Where(u => mediaIds.Contains(u.Id))
                .Select(u => u.Id)
                .ToListAsync();

            return new HashSet<Guid>(list);
        }

        public async Task<List<Guid>> GetExistingIdsAsync(List<Guid> ids)
        {
            if (ids == null || !ids.Any())
                return new List<Guid>();

            return await _dbSet
                .AsNoTracking()
                .Where(m => ids.Contains(m.Id))
                .Select(m => m.Id)
                .ToListAsync();
        }

        public async Task<List<MediaRecommendationDto>> GetRecommendedMediasAsync(Guid currentMediaId, int limit = 10)
        {
            var currentMediaType = await _db.Medias.AsNoTracking()
                .Where(x => x.Id == currentMediaId)
                .Select(x => x.Type)
                .FirstOrDefaultAsync();

            var query = from m in _db.Medias.AsNoTracking()
                        join mc in _db.MediaCategories on m.Id equals mc.MediaId
                        where m.Type == currentMediaType
                        && mc.CategoryId == (
                            _db.MediaCategories
                                .Where(x => x.MediaId == currentMediaId)
                                .Select(x => x.CategoryId)
                                .FirstOrDefault()
                        )
                        && m.Id != currentMediaId
                        select m;

            // Map thẳng sang DTO ở tầng Database (LINQ to Entities)
            var recommendedMedias = await query
                .OrderBy(x => EF.Functions.Random())
                .Take(limit)
                .Select(m => new MediaRecommendationDto
                {
                    Id = m.Id,
                    Title = m.Title,
                    Description = m.Description,
                    Thumbnail = m.Thumbnail,
                    Duration = m.Duration,
                    Type = m.Type,
                    User = m.User != null ? new UserDto
                    {
                        Id = m.User.Id,
                        Username = m.User.Username,
                        Email = m.User.Email
                    } : null
                })
                .ToListAsync();

            // Fallback luồng tương tự
            if (recommendedMedias == null || !recommendedMedias.Any())
            {
                recommendedMedias = await _db.Medias.AsNoTracking()
                    .Where(m => m.Id != currentMediaId && m.Type == currentMediaType)
                    .OrderByDescending(m => m.Id)
                    .Take(limit)
                    .Select(m => new MediaRecommendationDto
                    {
                        Id = m.Id,
                        Title = m.Title,
                        Description = m.Description,
                        Thumbnail = m.Thumbnail,
                        Duration = m.Duration,
                        Type = m.Type,
                        User = m.User != null ? new UserDto
                        {
                            Id = m.User.Id,
                            Username = m.User.Username,
                            Email = m.User.Email
                        } : null
                    })
                    .ToListAsync();
            }

            return recommendedMedias;
        }
    }
}