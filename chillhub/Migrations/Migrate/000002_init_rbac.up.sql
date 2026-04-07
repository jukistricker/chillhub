-- 1. Thêm Group RBAC (Dùng để quản lý các quyền liên quan đến phân quyền)
INSERT INTO public.permission_groups (name, code, sort_order)
VALUES ('RBAC Management', 'rbac_group.admin', 1)
    ON CONFLICT (code) DO NOTHING;
-- Dùng ON CONFLICT để tránh lỗi nếu bạn lỡ chạy script này 2 lần

-- 2. Thêm Permission hiện tại trong Controller và trỏ tới Group vừa tạo
INSERT INTO public.permissions (code, permission_group_id)
VALUES ('rbac.save_permission_group',(SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin' LIMIT 1)),
        ('rbac.search_permission_groups',(SELECT id FROM public.permission_groups WHERE code = 'rbac_group.admin' LIMIT 1))
ON CONFLICT (code) DO NOTHING;

-- 2. Gán quyền rbac.save_permission_group cho Role Admin
-- Chúng ta dùng Subquery để lấy ID của Role và Permission theo Name/Code cho chính xác
INSERT INTO public.role_permissions (role_id, permission_id)
VALUES (
           (SELECT id FROM public.roles WHERE "name" = 'admin' LIMIT 1),
       (SELECT id FROM public.permissions WHERE code = 'rbac.save_permission_group' LIMIT 1)
    )
ON CONFLICT (role_id, permission_id) DO NOTHING;