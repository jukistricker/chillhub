using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories;

public class RbacRepository : Repository<Permission>, IRbacRepository
{
    private readonly AppDbContext _db;

    public RbacRepository(AppDbContext dbContext) : base(dbContext)
    {
        _db = dbContext;
    }

    // public async Task<PermissionGroupDetailDto?> GetGroupPermissionDetailAsync(Guid groupPermissionId)
    // {
    //     // Sử dụng Query Projection để tránh lỗi Ambiguous và tối ưu RAM
    // IQueryable<PermissionGroupDetailDto> query = _db.PermissionGroups
    //         .AsNoTracking()
    //         .Where(g => g.Id == groupPermissionId)
    //         .Select(g => new PermissionGroupDetailDto(
    //             g.Id, 
    //             g.Name, 
    //             g.Code,
    //             _db.Permissions
    //                 .Where(p => p.PermissionGroupId == g.Id)
    //                 .Select(p => new PermissionDto(p.Id, p.Code))
    //                 .ToList() 
    //         ));
    //
    //     return await query.FirstOrDefaultAsync();
    // }

    public async Task<bool> CheckGroupCodeExistsAsync(string code, Guid? excludeId = null)
    {
        return await _db.PermissionGroups
            .AsNoTracking()
            .AnyAsync(g => g.Code == code && (!excludeId.HasValue || g.Id != excludeId.Value));
    }

    public async Task<PermissionGroup> SavePermissionGroupAsync(PermissionGroup entity, bool isUpdate)
    {
        if (isUpdate)
        {
            // Chỉ Attach và đánh dấu Modified (0 Roundtrip SELECT)
            _db.PermissionGroups.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        else
        {
            _db.PermissionGroups.Add(entity);
        }

        // Đẩy xuống DB 
        // Lỗi Unique/Concurrency sẽ sinh tại đây và bay thẳng lên GEH
        await _db.SaveChangesAsync();
        return entity;
    }

   


    // public async Task<RoleDetailDto?> GetRoleDetailAsync(Guid roleId)
    // {
    //     return await _db.Roles
    //         .AsNoTracking()
    //         .Where(r => r.Id == roleId)
    //         .Select(r => new RoleDetailDto(
    //             r.Id, 
    //             r.Name,
    //             _db.RolePermissions
    //                 .Where(rp => rp.RoleId == r.Id)
    //                 .Select(rp => new PermissionDto(rp.PermissionId, rp.Permission.Code))
    //                 .ToList()
    //         )).FirstOrDefaultAsync();
    // }

    public async Task UpdateRolePermissionsAsync(Guid roleId, List<Guid> permissionIds)
    {
        // Xóa cũ bằng ExecuteDelete 
        await _db.RolePermissions
            .Where(rp => rp.RoleId == roleId)
            .ExecuteDeleteAsync();

        // Thêm mới
        if (permissionIds.Any())
        {
            var newItems = permissionIds.Select(pId => new RolePermission
            {
                RoleId = roleId,
                PermissionId = pId
            });
            await _db.RolePermissions.AddRangeAsync(newItems);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<bool> SavePermissionBatchAsync(List<Permission> permissions, List<RolePermission> rolePermissions)
    {
        try
        {
            await _db.Permissions.AddRangeAsync(permissions);
            await _db.RolePermissions.AddRangeAsync(rolePermissions);
            return await _db.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine( "Internal Server Error. Details: ",
                ex.InnerException?.Message ?? ex.Message);
            _db.ChangeTracker.Clear();
            return false;
        }
    }

    public async Task<List<Permission>> GetPermissionsByIds(List<Guid> ids)
    {
        return await _db.Permissions
            .Where(p => ids.Contains(p.Id))
            .ToListAsync();
    }

    public async Task<bool> UpsertPermissionsBatchAsync(
        List<Guid> idsToSyncRoles,
        List<Permission> permissions,
        List<RolePermission> rolePermissions)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        try
        {
            // 1. Xóa sạch Role cũ của các Permission có trong Request (Full Sync)
            if (idsToSyncRoles.Any())
                await _db.RolePermissions
                    .Where(rp => idsToSyncRoles.Contains(rp.PermissionId))
                    .ExecuteDeleteAsync();

            // 2. Cập nhật Permission (Xử lý Identity Conflict)
            foreach (var p in permissions)
            {
                // Kiểm tra xem EF Core có đang track thằng nào trùng Id không
                var trackedEntry = _db.ChangeTracker.Entries<Permission>()
                    .FirstOrDefault(e => e.Entity.Id == p.Id);

                if (trackedEntry != null)
                {
                    // Nếu đang track (do bước GetById ở Service), ta ghi đè giá trị mới vào thằng đang được track
                    trackedEntry.CurrentValues.SetValues(p);
                    trackedEntry.State = EntityState.Modified;
                }
                else
                {
                    // Nếu chưa track, ta dùng Attach và mark Modified
                    _db.Permissions.Attach(p);
                    _db.Entry(p).State = EntityState.Modified;
                }

                // Nếu bạn muốn bỏ qua không cho phép sửa Code ở bước Update:
                // _db.Entry(p).Property(x => x.Code).IsModified = false;
            }

            // 3. Chèn Role mới (Nếu rolePermissions rỗng, kết quả là Permission đó sạch Role)
            if (rolePermissions.Any()) await _db.RolePermissions.AddRangeAsync(rolePermissions);

            await _db.SaveChangesAsync();
            await transaction.CommitAsync();
            return true;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _db.ChangeTracker.Clear(); 
            return false;
        }
    }

    public async Task<List<string>> ValidPermissionCodes(List<string> codes)
    {
        if (codes == null || !codes.Any()) return new List<string>();
        return await _db.Permissions
            .Where(p => codes.Contains(p.Code))
            .Select(p => p.Code).ToListAsync();
    }

    public async Task<List<Guid>> ValidPermissionGroups(List<Guid> groupIds)
    {
        if (groupIds == null || !groupIds.Any()) return new List<Guid>();
        return await _db.PermissionGroups
            .Where(g => groupIds.Contains(g.Id))
            .Select(g => g.Id).ToListAsync();
    }

    public async Task<List<Guid>> ValidRoles(List<Guid> roleIds)
    {
        if (roleIds == null || !roleIds.Any()) return new List<Guid>();
        return await _db.Roles
            .Where(r => roleIds.Contains(r.Id))
            .Select(r => r.Id).ToListAsync();
    }

    public async Task<CursorResponse<Permission>> GetPermissionsAsync(PermissionFilterRequest request)
    {
        IQueryable<Permission> query = _db.Permissions.AsNoTracking()
            .Include(x => x.PermissionGroup)
            .Include(x => x.RolePermissions)
                .ThenInclude(rp => rp.Role);

        if (request.Id.HasValue)
        {
            query = query.Where(x => x.Id == request.Id);
        }
        if (request.PermissionGroupId.HasValue)
            query = query.Where(x => x.PermissionGroupId == request.PermissionGroupId);

        if (request.RoleId.HasValue)
            query = query.Where(x => x.RolePermissions.Any(rp => rp.RoleId == request.RoleId));

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(x => x.Name.Contains(request.Search) || x.Code.Contains(request.Search));

        return await GetByCursorAsync(query, request, u => u.Id);
    }

    public async Task<List<UserRole>> GetUserRolesAsync(Guid userId)
    {
        return await _db.UserRoles
            .Where(ur => ur.UserId == userId)
            .ToListAsync();
    }

    public Task Update<T>(T entity) where T : class
    {
        _db.Set<T>().Update(entity);
        return Task.CompletedTask;
    }

    public void Add<T>(T entity) where T : class
    {
        _db.Set<T>().Add(entity);
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await _db.Set<T>().AddAsync(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
        _db.Set<T>().Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _db.SaveChangesAsync() > 0;
    }
    
    public void Remove<T>(T entity) where T : class
    {
        _db.Set<T>().Remove(entity);
    }

    public async Task<Role> SaveRoleAsync(Role entity, bool isUpdate)
    {
        if (isUpdate)
        {
            _db.Roles.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
        else
        {
            _db.Roles.Add(entity);
        }

        await _db.SaveChangesAsync();
        return entity;
    }

    

    public async Task<List<PermissionGroup>> GetAllGroupsAsync()
    {
        return await _db.PermissionGroups.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
    }
}