namespace chillhub.Utils;

public static class DbErrorRegistry
{
    /** TODO: Tên key phải trùng với tên constraint trong DB để có thể map chính xác lỗi
        Key: Tên Constraint trong DB | Value: Thông điệp lỗi trả về cho Client **/
    private static readonly Dictionary<string, string> Mappers = new()
    {
        // Permission Groups
        { "permission_groups_code_key", "rbac.permission_group.code_exists" },
        {"permission_groups_pkey", "rbac.permission_group.id_exists" },
        
        // Permissions
        { "permissions_code_key", "rbac.permission.code_exists" },
        {"permissions_pkey", "rbac.permission.id_exists" },
        // Foreign Keys (check lỗi not exists khi insert/update)
        { "permissions_permission_group_id_fkey", "rbac.permission.group_not_found" },
        
        // Roles
        { "roles_name_key", "rbac.role.name_exists" },
        {"roles_pkey", "rbac.role.id_exists" },
        
        // Users
        { "users_username_key", "rbac.user.username_exists" },
        {"users_pkey", "rbac.user.id_exists" },
        {"users_email_key", "rbac.user.email_exists" },
        {"users_external_id_provider_key", "rbac.user.external_id_provider_exists" },
        

        
    };

    public static string? GetErrorMessage(string? constraintName)
    {
        if (string.IsNullOrEmpty(constraintName)) return null;
        return Mappers.GetValueOrDefault(constraintName);
    }
}