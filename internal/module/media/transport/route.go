package transport

import (
	"chillhub/internal/module/media/handler"
	"github.com/gin-gonic/gin"
)

func RegisterRoutes(r *gin.RouterGroup, h *handler.MediaHandler) {
    // Tạo group media
    media := r.Group("/media")
    {
        // Các route liên quan đến upload
        media.POST("/upload", h.InitUpload)
        media.POST("/large-upload", h.InitLargeUpload)
        media.POST("/:id/complete", h.CompleteUpload)

        // Các route liên quan đến truy vấn/stream
        media.GET("/:id/status", h.GetStatus)
        media.GET("/:id/stream", h.Stream)
    }
}

