using chillhub.Contexts;
using chillhub.Entities.Auth;
using chillhub.Mapper;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Repositories.Interfaces;
using chillhub.Utils;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Repositories;

public class RbacRepository : IRbacRepository
{
    private readonly AppDbContext _db;
    private readonly ILogger<RbacRepository> _logger;

    public RbacRepository(AppDbContext context, ILogger<RbacRepository> logger)
    {
        _db = context;
        _logger = logger;
    }

    // public async Task<PermissionGroupDetailDto?> GetGroupPermissionDetailAsync(Guid groupPermissionId)
    // {
    //     // Sử dụng Query Projection để tránh lỗi Ambiguous và tối ưu RAM
    //     IQueryable<PermissionGroupDetailDto> query = _db.PermissionGroups
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

    public async Task<(List<PermissionGroupResponse> Items, string? NextCursor)> GetPermissionGroupsAsync(
        PermissionGroupFilterRequest req)
    {
        var query = _db.PermissionGroups.AsNoTracking();

        if (req.Id.HasValue) query = query.Where(u => u.Id == req.Id.Value);
        if (!string.IsNullOrWhiteSpace(req.Code)) query = query.Where(u => u.Code == req.Code);
        if (!string.IsNullOrWhiteSpace(req.Search))
            query = query.Where(u => EF.Functions.ILike(u.Name, $"%{req.Search.Trim()}%"));

        var items = await query
            .ApplyCursor<PermissionGroup, Guid>(req.Cursor, req.SortField, req.IsDescending)
            .ApplyDeterministicSort(req.FullSortParam)
            .Take(req.Limit + 1)
            .ApplySelect<PermissionGroup, PermissionGroupResponse>(
                StringUtil.GetSelectFields<PermissionGroupResponse>(req.Select))
            .ToListAsync();

        string? nextCursor = null;
        if (items.Count > req.Limit)
        {
            var lastValidItem = items[req.Limit - 1];
            nextCursor = lastValidItem.GetType().GetProperty(req.SortField)?.GetValue(lastValidItem)?.ToString()
                         ?? lastValidItem.Id.ToString();

            items.RemoveAt(req.Limit);
        }

        return (items, nextCursor);
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
            _logger.LogError(ex, "Internal Server Error. Details: {Message}",
                ex.InnerException?.Message ?? ex.Message);
            // Dọn dẹp tracker nếu lưu thất bại để tránh ảnh hưởng các lệnh Save sau này
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
            _logger.LogError(ex, "Error when updating permission batch");
            await transaction.RollbackAsync();
            _db.ChangeTracker.Clear(); // Dọn dẹp ChangeTracker để tránh ảnh hưởng request sau
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

    public async Task<(List<PermissionResponse> Items, string? NextCursor)> GetPermissionsAsync(
        PermissionFilterRequest request)
    {
        // 1. Khởi tạo Query từ Entity 
        var query = _db.Permissions.AsNoTracking();

        // 2. Filter trên Entity (Tối ưu index)
        if (request.PermissionGroupId.HasValue)
            query = query.Where(x => x.PermissionGroupId == request.PermissionGroupId);

        if (request.RoleId.HasValue)
            query = query.Where(x => x.RolePermissions.Any(rp => rp.RoleId == request.RoleId));

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(x => x.Name.Contains(request.Search) || x.Code.Contains(request.Search));

        // 3. DÙNG MAPPER TẠI ĐÂY
        // Chuyển từ IQueryable<Permission> sang IQueryable<PermissionResponse>
        var dtoQuery = query.Select(RbacMapper.ToPermissionResponse); //Ngay tại đây

        // 4. Áp dụng Sorting & Cursor 
        // Lưu ý: Lúc này SortField phải khớp với thuộc tính trong PermissionResponse
        dtoQuery = dtoQuery.ApplyCursor<PermissionResponse, Guid>(request.Cursor, request.SortField,
            request.IsDescending);
        dtoQuery = dtoQuery.ApplyDeterministicSort(request.FullSortParam);

        // 5. Thực thi lấy dữ liệu (Limit + 1 để check trang sau)
        var items = await dtoQuery
            .Take(request.Limit + 1)
            .ToListAsync();

        // 6. Xử lý NextCursor
        string? nextCursor = null;
        if (items.Count > request.Limit)
        {
            var lastItem = items[request.Limit - 1];
            items.RemoveAt(request.Limit);

            var cursorValue = lastItem.GetType().GetProperty(request.SortField)?.GetValue(lastItem);
            nextCursor = cursorValue?.ToString();
        }

        return (items, nextCursor);
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

    public async Task<(List<Role> Items, string? NextCursor)> GetRolesAsync(RoleFilterRequest requests)
    {
        var query = _db.Roles.AsNoTracking();

        if (requests.Id.HasValue) query = query.Where(u => u.Id == requests.Id.Value);
        if (!string.IsNullOrWhiteSpace(requests.Search))
            query = query.Where(u => EF.Functions.ILike(u.Name, $"%{requests.Search.Trim()}%"));

        var items = await query
            .ApplyCursor<Role, Guid>(requests.Cursor, requests.SortField, requests.IsDescending)
            .ApplyDeterministicSort(requests.FullSortParam)
            .Take(requests.Limit + 1)
            .ApplySelect<Role, Role>(StringUtil.GetSelectFields<Role>(requests.Select))
            .ToListAsync();

        string? nextCursor = null;
        if (items.Count > requests.Limit)
        {
            var lastValidItem = items[requests.Limit - 1];
            nextCursor = lastValidItem.GetType().GetProperty(requests.SortField)?.GetValue(lastValidItem)?.ToString()
                         ?? lastValidItem.Id.ToString();

            items.RemoveAt(requests.Limit);
        }

        return (items, nextCursor);
    }

    public async Task<List<PermissionGroup>> GetAllGroupsAsync()
    {
        return await _db.PermissionGroups.AsNoTracking().OrderBy(x => x.SortOrder).ToListAsync();
    }
}