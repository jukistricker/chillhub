SET client_encoding = 'UTF8';

-- ================================
-- Remove seeded admin user
-- ================================
DELETE FROM public.user_roles
WHERE user_id IN (
    SELECT id FROM public.users WHERE username = 'admin'
);

DELETE FROM public.users
WHERE username = 'admin';

-- ================================
-- Remove role_permissions
-- ================================
DELETE FROM public.role_permissions
WHERE role_id IN (
    SELECT id FROM public.roles WHERE name IN ('admin','user')
);

-- ================================
-- Remove permissions
-- ================================
DELETE FROM public.permissions
WHERE code IN (
    'auth.login',
    'auth.logout',
    'user.read',
    'user.create',
    'user.update',
    'user.delete'
);

-- ================================
-- Remove permission groups
-- ================================
DELETE FROM public.permission_groups
WHERE code IN ('auth_group','user_group');

-- ================================
-- Remove roles
-- ================================
DELETE FROM public.roles
WHERE name IN ('admin','user');

-- ================================
-- Drop tables (reverse dependency order)
-- ================================
DROP TABLE IF EXISTS public.user_roles;

DROP TABLE IF EXISTS public.role_permissions;

DROP TABLE IF EXISTS public.users;

DROP TABLE IF EXISTS public.permissions;

DROP TABLE IF EXISTS public.permission_groups;

DROP TABLE IF EXISTS public.roles;

-- ================================
-- Drop extension (optional)
-- ================================
DROP EXTENSION IF EXISTS "uuid-ossp";

-- ================================
-- Done
-- ================================
DO $$
BEGIN
    RAISE NOTICE 'ROLLBACK SUCCESSFUL';
END $$;