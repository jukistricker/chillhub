using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Repositories.Interfaces;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories;

public class AuthRepository: IAuthRepository
{
    private readonly AppDbContext _db;

    public AuthRepository(AppDbContext db)
    {
        _db = db;
    }

    public Task<bool> UsernameExistsAsync(string username)
        => _db.Users.AnyAsync(u => u.Username == username);

    public Task<User?> GetByUsernameAsync(string username)
        => _db.Users.FirstOrDefaultAsync(u => u.Username == username);

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
    
    public async Task<UserFullInfo> GetFullUserInfoAsync(string username)
    {
        var data = await _db.Users
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

    public Task AddUserAsync(User user)
        => _db.Users.AddAsync(user).AsTask();

    public Task AddUserRolesAsync(IEnumerable<UserRole> roles)
        => _db.UserRoles.AddRangeAsync(roles);
    
    public async Task<(List<UserResponse> Items, string? NextCursor)> GetUsersAsync(AuthFilterRequest req)
    {
        IQueryable<User> query = _db.Users.AsNoTracking();

        // --- STEP 0: BUSINESS FILTERS (Thủ công) ---
        if (req.Id.HasValue) query = query.Where(u => u.Id == req.Id.Value);
        if (!string.IsNullOrWhiteSpace(req.Username)) query = query.Where(u => u.Username == req.Username);
        if (!string.IsNullOrWhiteSpace(req.Search))
        {
            query = query.Where(u => EF.Functions.ILike(u.FullName, $"%{req.Search.Trim()}%"));
        }

        // --- STEP 1: THE PIPELINE (Dùng trực tiếp Helper từ 'req') ---
        List<UserResponse> items = await query
            .ApplyCursor<User, Guid>(req.Cursor, req.SortField, req.IsDescending) 
            .ApplyDeterministicSort(req.FullSortParam)
            .Take(req.Limit + 1)
            .ApplySelect<User, UserResponse>(StringUtil.GetSelectFields<UserResponse>(req.Select))
            .ToListAsync();

        // --- STEP 2: NEXT CURSOR ---
        string? nextCursor = null;
        if (items.Count > req.Limit)
        {
            UserResponse lastValidItem = items[req.Limit - 1];
        
            // Dùng Reflection nhẹ để lấy giá trị Cursor dựa trên SortField (Hoặc ép cứng Id nếu bạn chỉ dùng Id làm Cursor)
            nextCursor = lastValidItem.GetType().GetProperty(req.SortField)?.GetValue(lastValidItem)?.ToString() 
                         ?? lastValidItem.Id.ToString();
            
            items.RemoveAt(req.Limit);
        }
        return (items, nextCursor);
    }
    
    public Task SaveChangesAsync()
        => _db.SaveChangesAsync();
}