using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories;

public class RoleRepository : Repository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<CursorResponse<Role>> GetRolesAsync(RoleFilterRequest request)
    {
        IQueryable<Role> query = _dbSet.AsNoTracking();

        if (request.Id.HasValue)
            query = query.Where(x => x.Id == request.Id);

        return await GetByCursorAsync(query, request, u => u.Id);
    }

}
