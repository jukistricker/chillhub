ALTER TABLE public.permissions
    ADD COLUMN IF NOT EXISTS name VARCHAR(255);

-- Xóa dữ liệu cũ hoặc dùng ON CONFLICT để update name
INSERT INTO public.permissions (code, name, permission_group_id)
VALUES
    ('auth.login', 'Login', (SELECT id FROM public.permission_groups WHERE code = 'auth_group')),
    ('auth.logout', 'Logout', (SELECT id FROM public.permission_groups WHERE code = 'auth_group')),

    ('user.view_users', 'View Users', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    ('user.read', 'View User''s Details', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    ('user.create', 'Add New User', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    ('user.update', 'Update User''s Details', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    ('user.delete', 'Delete User', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),

    ('rbac.save_permission_group', 'Save Permission Group', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    ('rbac.save_role', 'Save Role', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    ('rbac.search_roles', 'Search Roles', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    ('rbac.save_permission', 'Save Permissions', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    ('rbac.search_permissions', 'Search Permissions', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    ('rbac.search_permission_groups','Search Permission Groups', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin')),
    ('auth.view_session','Get Session', (SELECT id FROM public.permission_groups WHERE code = 'user_group')),
    ('rbac.assign_role','Assign Roles', (SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin'))

    ON CONFLICT (code) DO UPDATE SET name = EXCLUDED.name;

INSERT INTO public.role_permissions (role_id, permission_id)
SELECT
    (SELECT id FROM public.roles WHERE name = 'admin' LIMIT 1), -- Lấy ID của role admin
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
-- Đảm bảo không chèn trùng nếu bản ghi đã tồn tại
ON CONFLICT (role_id, permission_id) DO NOTHING;