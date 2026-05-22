CREATE TABLE videos (
                        id UUID PRIMARY KEY DEFAULT uuid_generate_v7(),
                        title VARCHAR(255) NOT NULL,
                        storage_type VARCHAR(10) CHECK (storage_type IN ('MINIO', 'R2')) NOT NULL,
                        bucket_name VARCHAR(63) NOT NULL,
                        folder_path TEXT NOT NULL,
                        thumbnail_url TEXT,
                        duration INT,
                        is_public BOOLEAN DEFAULT false,
                        created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

-- Index cho created_at để load danh sách video mới nhất nhanh hơn
CREATE INDEX idx_videos_created_at ON videos(created_at DESC);

-- Index cho is_public để lọc các video đã sẵn sàng
CREATE INDEX idx_videos_is_public ON videos(is_public);