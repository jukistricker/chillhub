using chillhub.Contexts;
using chillhub.Entities;
using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class UserNotificationRepository : Repository<UserNotification>, IUserNotificationRepository
    {
        public UserNotificationRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CursorResponse<UserNotification>> GetUserNotificationsAsync(NotificationFilterRequest request)
        {
            var query = GetQueryable().AsNoTracking();
            query = query.Where(n => n.UserId == request.UserId);

            return await GetByCursorAsync(query, request, u => u.Id);
        }

        public async Task<UserNotification> GetByUserIdAsync(Guid notificationId, Guid userId)
        {
            return await _dbSet.FirstOrDefaultAsync(n => n.Id == notificationId && n.UserId == userId);
        }

        public async Task UpdateAllByUserIdAsync(Guid userId)
        {
            await _dbSet.Where(n => n.UserId == userId && !n.IsRead)
            .ExecuteUpdateAsync(setter => setter.SetProperty(n => n.IsRead, true));
        }
    }
}
