package main

import (
	"chillhub/internal/config"
	"chillhub/internal/module/media"
	"chillhub/internal/module/media/repository"
	mediaTransport "chillhub/internal/module/media/transport"
	"chillhub/internal/shared/middleware"
	minioshared "chillhub/internal/shared/minio"
	mongoshared "chillhub/internal/shared/mongo"
	"log" // Thêm thư viện log
	"os"

	"github.com/gin-contrib/cors"
	"github.com/gin-gonic/gin"
)

func main() {
	// 1. Load cấu hình
	cfg := config.Load()
	log.Println("Cấu hình đã được tải thành công...")


	// 2. Kết nối MongoDB
	db, err := mongoshared.Connect(cfg.MongoURI, cfg.MongoDB)
	if err != nil {
		log.Fatalf("Lỗi kết nối MongoDB: %v", err) // Dừng chương trình nếu lỗi
	}
	log.Println("Kết nối MongoDB thành công!")

	// 3. Kết nối MinIO
	minioClient, err := minioshared.NewClient(
		cfg.MinioEndpoint,
		cfg.MinioKey,
		cfg.MinioSecret,
		cfg.MinioUseSSL,
		cfg.MinioBaseURL,
	)
	if err != nil {
		log.Fatalf("Lỗi kết nối MinIO: %v", err)
	}

	minioUtil := minioshared.NewUtil(minioClient)



	// 5. Khởi tạo Modules
	repo := repository.NewMediaMongo(db)
	mediaModule := media.NewModule(repo, minioUtil) 


	// 6. Cấu hình Router
	debug := os.Getenv("APP_ENV") != "production"
	r := gin.Default()

    // Cấu hình CORS mở cho Localhost
    r.Use(cors.New(cors.Config{
        // Cho phép cả 127.0.0.1 và localhost với các cổng phổ biến
        AllowOrigins: []string{
            "http://127.0.0.1:5500", // Live Server VS Code
            "http://localhost:5500",
            "http://127.0.0.1:3000", // React/Next.js
            "http://localhost:3000",
        },
        AllowMethods:     []string{"GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS"},
        AllowHeaders:     []string{"Origin", "Content-Type", "Authorization"},
        // CỰC KỲ QUAN TRỌNG: Phải Expose ETag để FE đọc được từ MinIO/S3
        ExposeHeaders:    []string{"Content-Length", "ETag"}, 
        AllowCredentials: true,
    }))

	// Cấu hình Middleware xử lý lỗi
	r.Use(middleware.ErrorHandler(debug))

	api := r.Group("/api")
	mediaTransport.RegisterRoutes(api, mediaModule.Handler)

	// 7. Chạy Server
	log.Printf("Server đang chạy tại cổng: %s", cfg.Port)
	if err := r.Run(":" + cfg.Port); err != nil {
		log.Fatalf("Không thể khởi động server: %v", err)
	}
}