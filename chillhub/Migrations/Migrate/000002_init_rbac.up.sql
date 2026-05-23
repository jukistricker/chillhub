-- 1. Thêm Group RBAC
INSERT INTO public.permission_groups (id, name, code, sort_order)
VALUES (uuid_generate_v7(), 'RBAC Management', 'rbac_group.admin', 1)
ON CONFLICT (code) DO NOTHING;

-- 2. Thêm Permissions
-- Sử dụng uuid_generate_v7() cho cột id
INSERT INTO public.permissions (id, code, permission_group_id)
VALUES 
    (
        uuid_generate_v7(), 
        'rbac.save_permission_group', 
        (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin' LIMIT 1)
    ),
    (
        uuid_generate_v7(), 
        'rbac.search_permission_groups', 
        (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin' LIMIT 1)
    )
ON CONFLICT (code) DO NOTHING;

-- 3. Gán quyền rbac.save_permission_group cho Role Admin
-- Chúng ta dùng Subquery để lấy ID của Role và Permission theo Name/Code cho chính xác
INSERT INTO public.role_permissions (role_id, permission_id)
VALUES (
           (SELECT id FROM public.roles WHERE "name" = 'admin' LIMIT 1),
       (SELECT id FROM public.permissions WHERE code = 'rbac.save_permission_group' LIMIT 1)
    )
ON CONFLICT (role_id, permission_id) DO NOTHING;