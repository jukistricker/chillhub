-- 1. Đảm bảo cột name tồn tại
ALTER TABLE public.permissions
    ADD COLUMN IF NOT EXISTS name VARCHAR(255);

-- 2. Insert Permissions kèm theo ID tự sinh
-- Sử dụng cấu trúc VALUES để dễ dàng chèn thêm uuid_generate_v7()
INSERT INTO public.permissions (id, code, name, permission_group_id)
VALUES 
    (uuid_generate_v7(), 'auth.login', 'Login', (SELECT id FROM public.permission_groups WHERE code = 'auth_group')),
    (uuid_generate_v7(), 'auth.logout', 'Logout', (SELECT id FROM public.permission_groups WHERE code = 'auth_group')),
    (uuid_generate_v7(), 'user.view_users', 'View Users', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    (uuid_generate_v7(), 'user.read', 'View User''s Details', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    (uuid_generate_v7(), 'user.create', 'Add New User', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    (uuid_generate_v7(), 'user.update', 'Update User''s Details', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    (uuid_generate_v7(), 'user.delete', 'Delete User', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    (uuid_generate_v7(), 'rbac.save_permission_group', 'Save Permission Group', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    (uuid_generate_v7(), 'rbac.save_role', 'Save Role', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    (uuid_generate_v7(), 'rbac.search_roles', 'Search Roles', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    (uuid_generate_v7(), 'rbac.save_permission', 'Save Permissions', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    (uuid_generate_v7(), 'rbac.search_permissions', 'Search Permissions', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    (uuid_generate_v7(), 'rbac.search_permission_groups', 'Search Permission Groups', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    (uuid_generate_v7(), 'auth.view_session', 'Get Session', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    (uuid_generate_v7(), 'rbac.assign_role', 'Assign Roles', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin'))
ON CONFLICT (code) DO UPDATE SET 
    name = EXCLUDED.name,
    permission_group_id = EXCLUDED.permission_group_id;

-- 3. Insert vào bảng trung gian (Không cần id)
INSERT INTO public.role_permissions (role_id, permission_id)
SELECT    
    (SELECT id FROM public.roles WHERE name = 'admin' LIMIT 1), 
    p.id
FROM public.permissions p
WHERE p.code IN (
    'rbac.search_permission_groups',
    'rbac.save_permission_group',
    'rbac.save_role',
    'rbac.search_roles',
    'rbac.save_permission',
    'rbac.search_permissions',
    'auth.view_session',
    'rbac.assign_role'
)
ON CONFLICT (role_id, permission_id) DO NOTHING;