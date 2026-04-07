using chillhub.Entities.Auth;
using chillhub.Models.Dtos.Requests;
using chillhub.Models.Dtos.Responses;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Models.Dtos.Responses.Shared;
using chillhub.Repositories.Interfaces;
using chillhub.Services.Interfaces.Rbac;

namespace chillhub.Services.Rbac;

public class RbacService : IRbacService
{
    private readonly IRbacRepository _rbacRepo;

    public RbacService(IRbacRepository repo)
    {
        _rbacRepo = repo;
    }

    public async Task<IResult> CreatePermissionGroupAsync(PermissionGroupSaveRequest request)
    {
        var entity = request.ToEntity();
        entity.Id = Guid.Empty;
        entity = await _rbacRepo.SavePermissionGroupAsync(entity, false);
        return ResponseDto.Create(ResponseCatalog.Created, "rbac.permission_group.created", entity);
    }

    public async Task<IResult> UpdatePermissionGroupAsync(PermissionGroupSaveRequest request)
    {
        if (!request.Id.HasValue || request.Id == Guid.Empty)
            return ResponseDto.Create(ResponseCatalog.BadRequest, "rbac.permission_group.id_required");

        var entity = request.ToEntity();
        entity = await _rbacRepo.SavePermissionGroupAsync(entity, true);
        return ResponseDto.Create(ResponseCatalog.Success, "rbac.permission_group.updated", entity);
    }


    public async Task<IResult> SearchPermissionGroupsAsync(PermissionGroupFilterRequest request)
    {
        var (items, nextCursor) = await _rbacRepo.GetPermissionGroupsAsync(request);

        var response = new PagedResponse<PermissionGroupResponse>(items, nextCursor);
        return ResponseDto.Create(ResponseCatalog.Success, "rbac.permission_groups.list", response);
    }

    public async Task<IResult> CreateRoleAsync(RoleSaveRequest request)
    {
        var entity = request.ToEntity();
        entity.Id = Guid.Empty;
        entity = await _rbacRepo.SaveRoleAsync(entity, false);
        return ResponseDto.Create(ResponseCatalog.Created, "rbac.role.created", entity);
    }

    public async Task<IResult> UpdateRoleAsync(RoleSaveRequest request)
    {
        if (!request.Id.HasValue || request.Id == Guid.Empty)
            return ResponseDto.Create(ResponseCatalog.BadRequest, "rbac.role.id_required");

        var entity = request.ToEntity();
        entity = await _rbacRepo.SaveRoleAsync(entity, true);
        return ResponseDto.Create(ResponseCatalog.Success, "rbac.role.updated", entity);
    }

    public async Task<IResult> SearchRolesAsync(RoleFilterRequest request)
    {
        var (items, nextCursor) = await _rbacRepo.GetRolesAsync(request);

        var response = new PagedResponse<Role>(items, nextCursor);
        return ResponseDto.Create(ResponseCatalog.Success, "rbac.role.list", response);
    }

    public async Task<IResult> CreatePermissionAsync(List<PermissionSaveRequest> requests)
    {
        // 1. Thu thập dữ liệu đối chiếu (Thêm check null cho RoleId)
        var codesToCheck = requests.Select(r => r.Code).Distinct().ToList();

        var groupIdsToCheck = requests
            .Where(r => r.PermissionGroupId.HasValue)
            .Select(r => r.PermissionGroupId!.Value)
            .Distinct()
            .ToList();

        // Dùng ?? new List<Guid>() để SelectMany không bị nổ khi gặp null
        var roleIdsToCheck = requests
            .SelectMany(r => r.RoleId ?? new List<Guid>())
            .Distinct()
            .ToList();

        // 2. Một lượt quét Database
        var existingCodes = await _rbacRepo.ValidPermissionCodes(codesToCheck);
        var validGroupIds = await _rbacRepo.ValidPermissionGroups(groupIdsToCheck);
        var validRoleIds = roleIdsToCheck.Any()
            ? await _rbacRepo.ValidRoles(roleIdsToCheck)
            : new List<Guid>();

        // 3. Duyệt lỗi logic
        var errorList = new List<object>();
        var duplicateInRequest = requests.GroupBy(x => x.Code).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

        foreach (var req in requests)
        {
            var itemErrors = new List<string>();

            if (existingCodes.Contains(req.Code)) itemErrors.Add("rbac.permission.code_already_exists");
            if (duplicateInRequest.Contains(req.Code)) itemErrors.Add("rbac.permission.duplicate_code");

            // Check null PermissionGroupId trước khi Contains
            if (!req.PermissionGroupId.HasValue || !validGroupIds.Contains(req.PermissionGroupId.Value))
                itemErrors.Add("rbac.permission_group.not_found");

            // Kiểm tra RoleId: Chỉ check nếu RoleId không null và có phần tử
            if (req.RoleId != null && req.RoleId.Any(id => !validRoleIds.Contains(id)))
                itemErrors.Add("rbac.role.one_or_more_not_found");

            if (itemErrors.Any())
                errorList.Add(new { req.Code, Errors = itemErrors });
        }

        if (errorList.Any())
            return ResponseDto.Create(ResponseCatalog.BadRequest, "rbac.permission.save_failed", errorList);

        // 4. Mapping
        var permissions = new List<Permission>();
        var rolePermissions = new List<RolePermission>();

        foreach (var req in requests)
        {
            var pId = req.Id ?? Guid.CreateVersion7();
            permissions.Add(new Permission
            {
                Id = pId,
                Code = req.Code,
                Name = req.Name,
                PermissionGroupId = req.PermissionGroupId!.Value
            });

            // Chỉ AddRange nếu RoleId không null
            if (req.RoleId != null)
                rolePermissions.AddRange(req.RoleId.Select(rId => new RolePermission
                {
                    PermissionId = pId,
                    RoleId = rId
                }));
        }

        if (!await _rbacRepo.SavePermissionBatchAsync(permissions, rolePermissions))
            return ResponseDto.Create(ResponseCatalog.Internal, "rbac.permission.save_failed");

        return ResponseDto.Create(ResponseCatalog.Created, "rbac.permission.created");
    }

    public async Task<IResult> UpdatePermissionAsync(List<PermissionSaveRequest> requests)
    {
        // 1. Thu thập dữ liệu để check
        List<Guid> permissionIdsInRequest = requests.Where(r => r.Id.HasValue).Select(r => r.Id!.Value).ToList();
        List<string> codesInRequest = requests.Select(r => r.Code).Distinct().ToList();

        // Thu thập GroupId (Xử lý null để tránh lỗi Select)
        List<Guid> groupIdsToCheck = requests
            .Where(r => r.PermissionGroupId.HasValue)
            .Select(r => r.PermissionGroupId!.Value)
            .Distinct().ToList();

        // Thu thập RoleId (Xử lý null để SelectMany không crash)
        List<Guid> roleIdsToCheck = requests
            .SelectMany(r => r.RoleId ?? new List<Guid>())
            .Distinct().ToList();

        // 2. Quét DB một lần duy nhất
        List<Permission> existingInDb = await _rbacRepo.GetPermissionsByIds(permissionIdsInRequest);
        List<string> existingCodes = await _rbacRepo.ValidPermissionCodes(codesInRequest);
        List<Guid> validGroupIds = await _rbacRepo.ValidPermissionGroups(groupIdsToCheck);
        List<Guid> validRoleIds = roleIdsToCheck.Any()
            ? await _rbacRepo.ValidRoles(roleIdsToCheck)
            : new List<Guid>();

        // 3. Bắt lỗi logic
        List<object> errorList = new List<object>();
        List<string> duplicateInRequest = requests.GroupBy(x => x.Code).Where(g => g.Count() > 1).Select(g => g.Key).ToList();

        foreach (PermissionSaveRequest req in requests)
        {
            List<string> itemErrors = new List<string>();

            // Check tồn tại Permission
            if (req.Id.HasValue && !existingInDb.Any(p => p.Id == req.Id))
                itemErrors.Add("rbac.permission.not_found");

            // Check GroupId
            if (!req.PermissionGroupId.HasValue || !validGroupIds.Contains(req.PermissionGroupId.Value))
                itemErrors.Add("rbac.permission.group_not_found");

            // Check trùng Code (trừ chính nó)
            if (existingCodes.Contains(req.Code))
            {
                bool isOwnCode = req.Id.HasValue && existingInDb.Any(p => p.Id == req.Id && p.Code == req.Code);
                if (!isOwnCode) itemErrors.Add("rbac.permission.code_already_exists");
            }

            if (duplicateInRequest.Contains(req.Code))
                itemErrors.Add("rbac.permission.duplicate_code");

            // Validate RoleId: Chỉ check nếu RoleId có dữ liệu (Nếu null hoặc rỗng thì bỏ qua vì ta chấp nhận xóa hết)
            if (req.RoleId != null && req.RoleId.Any(id => !validRoleIds.Contains(id)))
                itemErrors.Add("rbac.role.one_or_more_not_found");

            if (itemErrors.Any()) errorList.Add(new { req.Code, Errors = itemErrors });
        }

        if (errorList.Any())
            return ResponseDto.Create(ResponseCatalog.BadRequest, "rbac.permission.save_failed", errorList);

        // 4. Phân loại để Upsert
        List<Permission> permissionsToSave = new List<Permission>();
        List<RolePermission> rolePermissionsToSave = new List<RolePermission>();

        foreach (PermissionSaveRequest req in requests)
        {
            bool isUpdate = req.Id.HasValue && existingInDb.Any(p => p.Id == req.Id);
            Guid pId = isUpdate ? req.Id!.Value : req.Id ?? Guid.CreateVersion7();

            permissionsToSave.Add(new Permission
            {
                Id = pId,
                Code = req.Code,
                Name = req.Name,
                PermissionGroupId = req.PermissionGroupId!.Value
            });

            // Ánh xạ Role: Nếu RoleId != null, thêm vào list re-insert. 
            // Nếu RoleId == null hoặc rỗng, không thêm gì (tức là sau khi xóa cũ sẽ không có gì mới)
            if (req.RoleId != null && req.RoleId.Any())
                rolePermissionsToSave.AddRange(req.RoleId.Select(rId => new RolePermission
                {
                    PermissionId = pId,
                    RoleId = rId
                }));
        }

        // 5. Lưu xuống Repo: idsInRequest chứa tất cả các ID cần được l
        if (!await _rbacRepo.UpsertPermissionsBatchAsync(permissionIdsInRequest, permissionsToSave, rolePermissionsToSave))
            return ResponseDto.Create(ResponseCatalog.Internal, "rbac.permission.save_failed");

        return ResponseDto.Create(ResponseCatalog.Success, "rbac.permission.update_success");
    }

    public async Task<IResult> SearchPermissionsAsync(PermissionFilterRequest request)
    {
        var (items, nextCursor) = await _rbacRepo.GetPermissionsAsync(request);

        var response = new PagedResponse<PermissionResponse>(items, nextCursor);
        return ResponseDto.Create(ResponseCatalog.Success, "rbac.permission.list", response);
    }

    public async Task<IResult> AssignRoleAsync(UserRoleAssignRequest request)
    {
        List<UserRole> existingUserRoles = await _rbacRepo.GetUserRolesAsync(request.UserId);
        HashSet<Guid> existingRoleIds = existingUserRoles.Select(ur => ur.RoleId).ToHashSet();
    
        // Dùng Dictionary: Key là ID của Role, Value là thông điệp lỗi
        Dictionary<Guid,string> errorMap = new Dictionary<Guid, string>();

        // 1. Check Giao thoa (Return sớm vì đây là lỗi logic request)
        List<Guid>? intersection = request.AddRoleIds?.Intersect(request.RemoveRoleIds ?? new HashSet<Guid>()).ToList();
        if (intersection?.Any() == true)
            return ResponseDto.Create(ResponseCatalog.BadRequest, "rbac.user_role.duplicate_in_add_and_remove", intersection);

        // 2. Xử lý Xóa
        if (request.RemoveRoleIds != null)
        {
            foreach (var roleId in request.RemoveRoleIds)
            {
                UserRole? toRemove = existingUserRoles.FirstOrDefault(ur => ur.RoleId == roleId);
                if (toRemove == null) 
                    errorMap[roleId] = "rbac.user_role.not_found_for_removal"; // Key-Value
                else 
                    _rbacRepo.Remove(toRemove);
            }
        }

        // 3. Xử lý Thêm
        if (request.AddRoleIds != null)
        {
            foreach (var roleId in request.AddRoleIds)
            {
                if (existingRoleIds.Contains(roleId)) 
                    errorMap[roleId] = "rbac.user_role.already_exists"; // Key-Value
                else 
                    _rbacRepo.Add(new UserRole { UserId = request.UserId, RoleId = roleId });
            }
        }

        // Nếu có lỗi, trả về Dictionary lỗi
        if (errorMap.Any()) 
            return ResponseDto.Create(ResponseCatalog.BadRequest, "rbac.user_role.validate_failed", errorMap);

        // 4. Lưu 1 lần duy nhất
        await _rbacRepo.SaveChangesAsync();

        return ResponseDto.Create(ResponseCatalog.Success, "rbac.user_role.assign_success");
    }
    
}