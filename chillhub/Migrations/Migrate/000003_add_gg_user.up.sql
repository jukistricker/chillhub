
ALTER TABLE public.users
    ADD COLUMN IF NOT EXISTS email varchar(255),
    ADD COLUMN IF NOT EXISTS full_name varchar(255),
    ADD COLUMN IF NOT EXISTS avatar_url text,
    ADD COLUMN IF NOT EXISTS provider varchar(50),
    ADD COLUMN IF NOT EXISTS external_id text;

ALTER TABLE public.users ALTER COLUMN "password" DROP NOT NULL;

DO $$
BEGIN
    -- Check và thêm Unique Email
    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'users_email_key') THEN
ALTER TABLE public.users ADD CONSTRAINT users_email_key UNIQUE (email);
END IF;

    IF NOT EXISTS (SELECT 1 FROM pg_constraint WHERE conname = 'users_external_id_provider_key') THEN
ALTER TABLE public.users ADD CONSTRAINT users_external_id_provider_key UNIQUE (external_id, provider);
END IF;
END $$;

-- 4. Tạo các Index (Đã có IF NOT EXISTS nên an toàn)
CREATE INDEX IF NOT EXISTS idx_users_external_auth ON public.users (external_id, provider);
CREATE INDEX IF NOT EXISTS idx_users_email ON public.users (email);
CREATE INDEX IF NOT EXISTS idx_users_created_at ON public.users (created_at DESC);