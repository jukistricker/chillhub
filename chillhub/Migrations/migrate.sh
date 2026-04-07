#!/bin/bash
set -e 

# Lấy đường dẫn tuyệt đối đến thư mục chứa script này
PARENT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
SQL_DIR="$PARENT_DIR/Migrate"

echo ">>> Checking Postgres status at $DB_HOST:$DB_PORT..."

# Đợi DB sẵn sàng
until pg_isready -h "$DB_HOST" -p "$DB_PORT" -U "$POSTGRES_USER"; do
  echo ">>> Postgres is starting up - waiting 2s..."
  sleep 2
done

echo ">>> Postgres is ready! Starting Migrations from $SQL_DIR..."

# Kiểm tra thư mục SQL
if [ ! -d "$SQL_DIR" ]; then
  echo ">>> Error: Directory $SQL_DIR not found!"
  exit 1
fi

# Chạy từng file SQL theo thứ tự bảng chữ cái
for f in $(ls "$SQL_DIR"/*.sql | sort); do
  echo ">>> Applying: $(basename "$f")"
  PGPASSWORD=$POSTGRES_PASSWORD psql -h "$DB_HOST" -p "$DB_PORT" -U "$POSTGRES_USER" -d "$POSTGRES_DB" -f "$f"
done

echo ">>> All migrations applied successfully. Launching App..."