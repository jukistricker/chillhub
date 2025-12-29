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
	r.Use(middleware.ErrorHandler(debug))

	api := r.Group("/api")
	mediaTransport.RegisterRoutes(api, mediaModule.Handler)

	// 7. Chạy Server
	log.Printf("Server đang chạy tại cổng: %s", cfg.Port)
	if err := r.Run(":" + cfg.Port); err != nil {
		log.Fatalf("Không thể khởi động server: %v", err)
	}
}