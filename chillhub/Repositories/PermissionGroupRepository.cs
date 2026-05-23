using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories;

public class PermissionGroupRepository : Repository<PermissionGroup>, IPermissionGroupRepository
{
    public PermissionGroupRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<CursorResponse<PermissionGroup>> GetPermissionGroupsAsync(PermissionGroupFilterRequest req)
    {
        IQueryable<PermissionGroup> query = _dbSet.AsNoTracking();

        if (req.Id.HasValue)
            query = query.Where(u => u.Id == req.Id.Value);

        if (!string.IsNullOrWhiteSpace(req.Code))
            query = query.Where(u => u.Code == req.Code);

        if (!string.IsNullOrWhiteSpace(req.Search))
            query = query.Where(u => EF.Functions.ILike(u.Name, $"%{req.Search.Trim()}%"));

        return await GetByCursorAsync(query, req, u => u.Id);
    }
}
