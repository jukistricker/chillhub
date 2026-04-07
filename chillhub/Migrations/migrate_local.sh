#!/bin/bash

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ENV_PATH="$(realpath "$SCRIPT_DIR/../../.env")"

export PGCLIENTENCODING=utf8

if [ ! -f "$ENV_PATH" ]; then
    echo -e "\e[31m[ERROR] Khong tim thay file .env tai: $ENV_PATH\e[0m"
    read -p "Press enter to exit..."
    exit 1
fi

echo -e "\e[33m--- Loading config from .env ---\e[0m"

# Load .env
set -o allexport
source "$ENV_PATH"
set +o allexport

function require_config() {
    local name=$1
    local value="${!name}"

    if [ -z "$value" ]; then
        echo -e "\e[31m[ERROR] Thieu bien trong .env: $name\e[0m"
        exit 1
    fi
}

require_config DB_HOST
require_config DB_PORT
require_config DB_USER
require_config DB_NAME
require_config DB_PASS

echo -e "\e[32mDatabase: $DB_HOST $DB_PORT $DB_USER $DB_NAME\e[0m"

if [ "$DB_HOST" = "postgres" ]; then
    DB_HOST="localhost"
fi

if ! command -v psql >/dev/null 2>&1; then
    echo -e "\e[31m[ERROR] Khong tim thay psql trong PATH!\e[0m"
    exit 1
fi

SQL_DIR="$SCRIPT_DIR/Migrate"

if [ ! -d "$SQL_DIR" ]; then
    echo -e "\e[31m[ERROR] Thu muc SQL khong ton tai: $SQL_DIR\e[0m"
    exit 1
fi

export PGPASSWORD="$DB_PASS"

echo -e "\e[32m--- Starting Migration to $DB_HOST ($DB_NAME) ---\e[0m"

mapfile -t files < <(ls "$SQL_DIR"/*.sql 2>/dev/null | sort)

for file in "${files[@]}"; do
    filename=$(basename "$file")

    echo -e "\e[36mApplying: $filename\e[0m"

    psql \
        -h "$DB_HOST" \
        -p "$DB_PORT" \
        -U "$DB_USER" \
        -d "$DB_NAME" \
        -v ON_ERROR_STOP=1 \
        -f "$file"

    if [ $? -ne 0 ]; then
        echo -e "\e[31m[LOI] Tai file: $filename\e[0m"
        unset PGPASSWORD
        exit 1
    fi
done

unset PGPASSWORD

echo -e "\e[32mMIGRATION SUCCESSFUL!\e[0m"