# ==========================================
# 1. Giai đoạn SDK - Chỉ Build và Publish (Không chạy Migration ở đây)
# ==========================================
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Cài đặt công cụ dotnet-ef
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

COPY ["chillhub/chillhub.csproj", "chillhub/"]
RUN dotnet restore "chillhub/chillhub.csproj"
COPY . .
WORKDIR "/src/chillhub"

RUN dotnet build "./chillhub.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./chillhub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# ==========================================
# 2. Giai đoạn Runtime - Chạy Migration, Procedure & Start App
# ==========================================
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Cần cài cả .NET SDK Runtime phụ trợ hoặc cách tốt nhất là dùng luôn image SDK cho việc chạy lệnh Update DB lúc runtime.
# Để đơn giản và không bị thiếu công cụ dotnet-ef tại runtime, ta copy luôn thư mục tools từ tầng build sang:
USER root
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*

# Copy mã nguồn đã publish
COPY --from=publish /app/publish .

# Chỉ copy duy nhất file SQL Store Procedure vào
COPY chillhub/Migrations/dashboard_procedure.sql ./dashboard_procedure.sql

# Đảm bảo quyền sở hữu cho user app
RUN chown -R $APP_UID:$APP_UID /app
USER $APP_UID

# ENTRYPOINT chuỗi lệnh: 
# 1. Chạy file SQL procedure của bạn vào DB (Sử dụng biến ConnectionString được map từ compose)
# 2. Khởi động ứng dụng .NET
# Lưu ý: Lệnh psql cần biến môi trường chuỗi kết nối dạng standard của Postgres (ví dụ: $DATABASE_URL), 
# hoặc bạn có thể cấu hình psql đọc trực tiếp thông số kết nối.
ENTRYPOINT ["/bin/bash", "-c", "psql \"$ConnectionStrings__DefaultConnection\" -f ./dashboard_procedure.sql && dotnet chillhub.dll"]