using chillhub.Contexts;
using chillhub.Entities;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories
{
    public class DashboardRepository : Repository<Dashboard>, IDashboardRepository
    {
        public DashboardRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<CursorResponse<Dashboard>> GetDashboardsAsync(CursorRequest request)
        {
            IQueryable<Dashboard> query = _dbSet.AsNoTracking();


            return await GetByCursorAsync(query, request, u => u.Id);
        }
    }
}
