# ==========================================
# 1. Giai đoạn SDK - Build & Chạy Migration
# ==========================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Cài đặt công cụ dotnet-ef để chạy lệnh update database
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

COPY ["chillhub/chillhub.csproj", "chillhub/"]
RUN dotnet restore "chillhub/chillhub.csproj"
COPY . .
WORKDIR "/src/chillhub"

# Thực hiện migration trực tiếp tại đây (Yêu cầu DB phải đang chạy và kết nối được)
RUN dotnet ef database update

RUN dotnet build "./chillhub.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ==========================================
# 2. Giai đoạn Publish
# ==========================================
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./chillhub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ==========================================
# 3. Giai đoạn Runtime - Chạy Store Procedure & Start App
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Chuyển sang root để cài đặt psql client
USER root
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*

# Copy mã nguồn đã publish
COPY --from=publish /app/publish .

# Chỉ copy duy nhất file SQL Store Procedure của bạn vào container
COPY chillhub/Migrations/dashboard_procedure.sql ./dashboard_procedure.sql

# Đảm bảo quyền sở hữu thư mục cho user app
RUN chown -R $APP_UID:$APP_UID /app
USER $APP_UID

# ENTRYPOINT: Chạy file procedure của bạn rồi khởi động ứng dụng
# (Lưu ý: Biến $DATABASE_URL cần được truyền từ docker-compose hoặc lệnh docker run)
ENTRYPOINT ["/bin/bash", "-c", "psql $DATABASE_URL -f ./dashboard_procedure.sql && dotnet chillhub.dll"]