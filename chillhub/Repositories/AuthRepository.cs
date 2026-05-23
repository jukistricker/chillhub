using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories;

public class AuthRepository : Repository<User>, IAuthRepository
{
    private readonly AppDbContext _db;
    public AuthRepository(AppDbContext dbContext) : base(dbContext)
    {
        _db = dbContext;
    }

    public Task<bool> UsernameExistsAsync(string username)
        => _dbSet.AnyAsync(u => u.Username == username);

    public Task<User?> GetByUsernameAsync(string username)
        => _dbSet.FirstOrDefaultAsync(u => u.Username == username);

    public async Task<Guid?> GetDefaultRoleIdAsync()
    {
        return await _db.Roles
            .Where(r => r.Name == "user")
            .Select(r => r.Id)
            .SingleOrDefaultAsync();
    }

    public async Task<List<Guid>> GetExistingRoleIdsAsync(HashSet<Guid> roleIds)
    {
        return await _db.Roles
            .Where(r => roleIds.Contains(r.Id))
            .Select(r => r.Id)
            .ToListAsync();
    }

    public async Task<HashSet<Guid>> GetUserRoleIdsAsync(Guid userId)
    {
        return (await _db.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.RoleId)
                .ToListAsync())
            .ToHashSet();
    }

    public async Task<HashSet<string>> GetUserPermissionCodesAsync(Guid userId)
    {
        return (await (from ur in _db.UserRoles
                       join rp in _db.RolePermissions on ur.RoleId equals rp.RoleId
                       join p in _db.Permissions on rp.PermissionId equals p.Id
                       where ur.UserId == userId
                       select p.Code)
                .Distinct()
                .ToListAsync())
            .ToHashSet();
    }

    public async Task<UserFullInfo?> GetFullUserInfoAsync(string username)
    {
        var data = await _dbSet
            .Where(u => u.Username == username)
            .Select(u => new
            {
                User = u,
                RoleIds = _db.UserRoles.Where(ur => ur.UserId == u.Id).Select(ur => ur.RoleId).ToList(),
                Permissions = (from ur in _db.UserRoles
                               join rp in _db.RolePermissions on ur.RoleId equals rp.RoleId
                               join p in _db.Permissions on rp.PermissionId equals p.Id
                               where ur.UserId == u.Id
                               select p.Code).Distinct().ToList()
            })
            .FirstOrDefaultAsync();

        if (data == null) return null;

        return new UserFullInfo(data.User, data.RoleIds.ToHashSet(), data.Permissions.ToHashSet());
    }

    public Task AddUserRolesAsync(IEnumerable<UserRole> roles)
        => _db.UserRoles.AddRangeAsync(roles);


    public async Task<CursorResponse<User>> GetUsersAsync(AuthFilterRequest req)
    {
        IQueryable<User> query = _dbSet.AsNoTracking();

        if (req.Id.HasValue)
        {
            query = query.Where(x => x.Id == req.Id);
        }

        if (!string.IsNullOrEmpty(req.Username))
        {
            query = query.Where(x=>x.Username  == req.Username);
        }

        if (!string.IsNullOrEmpty(req.Search))
        {
            query = query.Where(u => EF.Functions.ILike(u.FullName, $"%{req.Search.Trim()}%"));
        }
        
        return await GetByCursorAsync(query, req, u => u.Id);
    }

}