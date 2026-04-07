FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER root
RUN apt-get update && apt-get install -y postgresql-client && rm -rf /var/lib/apt/lists/*
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["chillhub/chillhub.csproj", "chillhub/"]
RUN dotnet restore "chillhub/chillhub.csproj"
COPY . .
WORKDIR "/src/chillhub"
RUN dotnet build "./chillhub.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./chillhub.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# 1. Chuyển sang ROOT để thực hiện các thao tác đặc quyền
USER root

# 2. Cài đặt các công cụ cần thiết
RUN apt-get update && apt-get install -y postgresql-client bash && rm -rf /var/lib/apt/lists/*

# 3. Copy source code và migrations
COPY --from=publish /app/publish .
COPY chillhub/Migrations ./Migrations

# 4. Copy và xử lý script entrypoint (Làm khi đang là root)
COPY entrypoint.sh /usr/local/bin/entrypoint.sh
RUN sed -i 's/\r$//' /usr/local/bin/entrypoint.sh && \
    chmod +x /usr/local/bin/entrypoint.sh

# 5. Xử lý script migration
RUN sed -i 's/\r$//' ./Migrations/migrate.sh && \
    chmod +x ./Migrations/migrate.sh

# 6. Đảm bảo user 'app' có quyền sở hữu toàn bộ thư mục /app (Nơi chứa cert nếu mount volume)
RUN chown -R $APP_UID:$APP_UID /app

# 7. Chuyển lại user không có đặc quyền để chạy app (Best Practice)
USER $APP_UID

# Dùng shell để chạy chuỗi lệnh
ENTRYPOINT ["/bin/bash", "-c", "./Migrations/migrate.sh && dotnet chillhub.dll"]