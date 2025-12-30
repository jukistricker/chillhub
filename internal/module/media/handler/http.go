package handler

import (
	"chillhub/internal/module/media/service"
	"chillhub/internal/shared/response"
	"net/http"

	"github.com/gin-gonic/gin"
    appErr "chillhub/internal/shared/error"
)

type MediaHandler struct {
	service   *service.MediaService
	rawBucket string
}

func NewMediaHandler(
	s *service.MediaService,
) *MediaHandler {
	return &MediaHandler{
		service:   s,
	}
}

func (h *MediaHandler) InitUpload(c *gin.Context) {
	media, url, err := h.service.InitUpload(c.Request.Context())
	if err != nil {
		c.Error(err) //  giao toàn quyền cho global handler
		return
	}

    response.Send(
        c,
        http.StatusCreated,
        "media.upload_initialized",
        gin.H{
            "id":         media.ID.Hex(),
            "upload_url": url,
        },
    )
}

func (h *MediaHandler) CompleteUpload(c *gin.Context) {
    mediaID := c.Param("id")
    
    if err := h.service.CompleteUpload(c.Request.Context(), mediaID); err != nil {
        c.Error(err)
        return
    }

    response.Send(
        c,
        http.StatusOK,
        "media.queued_transcoding",
        nil,
    )

}

func (h *MediaHandler) GetStatus(c *gin.Context) {
    media, err := h.service.GetByID(c.Request.Context(), c.Param("id"))
    if err != nil {
        c.Error(err)
        return
    }
    response.Send(
        c,
        http.StatusOK,
        "media.status_retrieved",
        gin.H{
            "id":     media.ID.Hex(),
            "status": media.Status, // pending, processing, ready, failed
        },
    )
}

func (h *MediaHandler) Stream(c *gin.Context) {
    // Giả sử bạn lấy ID từ URL: /media/stream/:id
    mediaID := c.Param("id")
    
    // 1. Tìm thông tin media từ DB để lấy bucket/object
    // (Bạn nên thêm hàm GetByID vào service)
    media, err := h.service.GetByID(c.Request.Context(), mediaID)
    if err != nil {
        c.Error(err)
        return
    }

    // 2. Lấy stream từ Service
    reader, contentLength, contentType, err := h.service.GetStream(
        c.Request.Context(), 
        media.Raw.Bucket, 
        media.Raw.Object,
    )
    if err != nil {
        c.Error(err)
        return
    }
    defer reader.Close()

    // 3. Đẩy stream về client
    extraHeaders := map[string]string{
        "Content-Disposition": "inline",
    }
    
    c.DataFromReader(http.StatusOK, contentLength, contentType, reader, extraHeaders)
}

func (h *MediaHandler) InitLargeUpload(c *gin.Context) {
    // 1. Khai báo struct để nhận input từ Client
    var input struct {
        FileSize int64 `json:"size" binding:"required,gt=0"`
    }

    // 2. Bind JSON và kiểm tra lỗi validate
    if err := c.ShouldBindJSON(&input); err != nil {
        c.Error(appErr.ErrBadRequest.WithErr(err, "media.invalid_input"))
        return
    }

    // 3. Gọi Service để lấy danh sách URL
    // fileSize được truyền vào để tính toán chia Part
    res, err := h.service.InitLargeUpload(c.Request.Context(), input.FileSize)
    if err != nil {
        c.Error(err) // Trình xử lý lỗi tự động lo phần còn lại
        return
    }

    // 4. Trả về thành công bằng hàm Send tinh gọn
    response.Send(c, http.StatusCreated, "media.init_success", res)
}
