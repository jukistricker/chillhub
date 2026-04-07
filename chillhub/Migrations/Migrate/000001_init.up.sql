SET client_encoding = 'UTF8';

-- 1. Cấu hình Schema và Extensions
CREATE SCHEMA IF NOT EXISTS public;
ALTER DATABASE postgres SET search_path TO public, "$user";
CREATE EXTENSION IF NOT EXISTS "uuid-ossp" SCHEMA public;

CREATE OR REPLACE FUNCTION public.uuid_generate_v7()
RETURNS uuid AS $$
DECLARE
v_time timestamp with time zone := clock_timestamp();
  v_secs bigint := extract(epoch from v_time);
  v_msec bigint := extract(milliseconds from v_time)::bigint % 1000;
  v_timestamp_ms bigint;
  v_unix_ts_ms_hex text;
  v_random_component text;
BEGIN
  -- 1. Tính toán timestamp theo miligiây
  v_timestamp_ms := (v_secs * 1000) + v_msec;
  v_unix_ts_ms_hex := lpad(to_hex(v_timestamp_ms), 12, '0');

  -- 2. Sinh thành phần ngẫu nhiên và chèn các bit Version (7) & Variant (8)
  -- Cấu trúc: [48 bits TS][4 bits Ver][12 bits Rand][2 bits Var][62 bits Rand]
  v_random_component := to_hex((floor(random() * 65536))::int); -- Ngẫu nhiên 4 ký tự hex

  -- 3. Ghép chuỗi theo đúng định dạng 8-4-4-4-12 của UUID
  -- Kết quả phải có dạng: xxxxxxxx-xxxx-7xxx-axxx-xxxxxxxxxxxx
RETURN (
    substr(v_unix_ts_ms_hex, 1, 8) || '-' ||
    substr(v_unix_ts_ms_hex, 9, 4) || '-' ||
    '7' || lpad(to_hex((floor(random() * 4096))::int), 3, '0') || '-' ||
    to_hex((8 + floor(random() * 4))::int) || lpad(to_hex((floor(random() * 4096))::int), 3, '0') || '-' ||
    lpad(to_hex((floor(random() * 281474976710656))::bigint), 12, '0')
    )::uuid;
END;
$$ LANGUAGE plpgsql VOLATILE;

-- 2. Tạo bảng Permission Groups
CREATE TABLE IF NOT EXISTS public.permission_groups (
                                                        id UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    name VARCHAR(255) NOT NULL,
    code VARCHAR(100) NOT NULL UNIQUE,
    sort_order INTEGER DEFAULT 0,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by UUID,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_by UUID
    );

-- 3. Tạo bảng Permissions
CREATE TABLE IF NOT EXISTS public.permissions (
                                                  id UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    code VARCHAR(100) NOT NULL UNIQUE,
    permission_group_id UUID NOT NULL REFERENCES public.permission_groups(id) ON DELETE CASCADE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by UUID,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_by UUID
    );

-- 4. Tạo bảng Roles
CREATE TABLE IF NOT EXISTS public.roles (
                                            id UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    name VARCHAR(100) NOT NULL UNIQUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by UUID,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_by UUID
    );

-- 5. Tạo bảng Users
CREATE TABLE IF NOT EXISTS public.users (
                                            id UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
    username VARCHAR(100) NOT NULL UNIQUE,
    password TEXT NOT NULL,
    lang INTEGER DEFAULT 0,
    created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    created_by UUID,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    updated_by UUID
    );

-- 6. Tạo bảng trung gian Role_Permissions
CREATE TABLE IF NOT EXISTS public.role_permissions (
                                                       role_id UUID NOT NULL REFERENCES public.roles(id) ON DELETE CASCADE,
    permission_id UUID NOT NULL REFERENCES public.permissions(id) ON DELETE CASCADE,
    PRIMARY KEY (role_id, permission_id)
    );

-- 7. Tạo bảng trung gian User_Roles
CREATE TABLE IF NOT EXISTS public.user_roles (
                                                 user_id UUID NOT NULL REFERENCES public.users(id) ON DELETE CASCADE,
    role_id UUID NOT NULL REFERENCES public.roles(id) ON DELETE CASCADE,
    PRIMARY KEY (user_id, role_id)
    );

--- SEED DATA ---

INSERT INTO public.roles (name)
VALUES ('admin'), ('user')
    ON CONFLICT (name) DO NOTHING;

INSERT INTO public.permission_groups (name, code, sort_order)
VALUES ('Auth', 'auth_group', 1), ('User', 'user_group', 2)
    ON CONFLICT (code) DO NOTHING;

-- Seed Permissions
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'auth.login', id FROM public.permission_groups WHERE code = 'auth_group'
    ON CONFLICT (code) DO NOTHING;
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'auth.logout', id FROM public.permission_groups WHERE code = 'auth_group'
    ON CONFLICT (code) DO NOTHING;
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'user.read', id FROM public.permission_groups WHERE code = 'user_group'
    ON CONFLICT (code) DO NOTHING;
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'user.create', id FROM public.permission_groups WHERE code = 'user_group'
    ON CONFLICT (code) DO NOTHING;
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'user.update', id FROM public.permission_groups WHERE code = 'user_group'
    ON CONFLICT (code) DO NOTHING;
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'user.delete', id FROM public.permission_groups WHERE code = 'user_group'
    ON CONFLICT (code) DO NOTHING;
INSERT INTO public.permissions (code, permission_group_id)
SELECT 'user.view_users', id FROM public.permission_groups WHERE code = 'user_group'
    ON CONFLICT (code) DO NOTHING;

-- Admin Role Permissions (Full)
INSERT INTO public.role_permissions (role_id, permission_id)
SELECT r.id, p.id FROM public.roles r CROSS JOIN public.permissions p
WHERE r.name = 'admin' ON CONFLICT DO NOTHING;

-- User Role Permissions (Limited)
INSERT INTO public.role_permissions (role_id, permission_id)
SELECT r.id, p.id FROM public.roles r
                           JOIN public.permissions p ON p.code IN ('auth.login', 'auth.logout', 'user.read', 'auth.view_users')
WHERE r.name = 'user' ON CONFLICT DO NOTHING;

-- Admin User Creation
DO $$
DECLARE
v_role_id UUID;
    v_admin_id UUID;
    v_hash TEXT := 'AQAAAAIAACcQAAAAEJL3PEfuwNrQOTsclnmWeXII/9NzpgehrbMF6gOzBfg4BjsiMVqewvfP5/LtaNKj4w==';
BEGIN
SELECT id INTO v_role_id FROM public.roles WHERE name = 'admin' LIMIT 1;

INSERT INTO public.users (username, password, lang)
VALUES ('admin', v_hash, 1)
    ON CONFLICT (username) DO UPDATE SET updated_at = NOW()
                                  RETURNING id INTO v_admin_id;

IF v_role_id IS NOT NULL AND v_admin_id IS NOT NULL THEN
        INSERT INTO public.user_roles (user_id, role_id)
        VALUES (v_admin_id, v_role_id)
        ON CONFLICT DO NOTHING;

UPDATE public.users SET created_by = v_admin_id, updated_by = v_admin_id WHERE id = v_admin_id;
END IF;
END $$;