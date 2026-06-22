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

# 1. Chuyển sang ROOT để cài đặt psql client
USER root
RUN apt-get update && apt-get install -y postgresql-client bash && rm -rf /var/lib/apt/lists/*

# 2. Copy source code đã publish
COPY --from=publish /app/publish .

# 3. Chỉ copy duy nhất file SQL Store Procedure vào container
COPY chillhub/Migrations/dashboard_procedure.sql ./dashboard_procedure.sql

# 4. Đảm bảo user 'app' có quyền sở hữu toàn bộ thư mục /app
RUN chown -R $APP_UID:$APP_UID /app

# 5. Chuyển lại user không có đặc quyền để chạy app (Best Practice)
USER $APP_UID

# Dùng shell để xử lý chuỗi kết nối trực tiếp tại Runtime và chạy file SQL
ENTRYPOINT ["/bin/bash", "-c", " \
    export PGCONNECTSTRING=$(echo $ConnectionStrings__DefaultConnection | sed -e 's/Host=/host=/g' -e 's/Port=/port=/g' -e 's/Database=/dbname=/g' -e 's/Username=/user=/g' -e 's/Password=/password=/g'); \
    echo '>>> Đang nạp Store Procedure từ dashboard_procedure.sql...'; \
    psql -f ./dashboard_procedure.sql && \
    echo '>>> Khởi động ứng dụng .NET...'; \
    dotnet chillhub.dll \
"]