package handler

import (
	"chillhub/internal/module/media/service"
	"chillhub/internal/shared/response"
	"log"
	"net/http"

	appErr "chillhub/internal/shared/error"

	"github.com/gin-gonic/gin"
	"github.com/minio/minio-go/v7"
)

type MediaHandler struct {
	service   *service.MediaService
	rawBucket string
}

func NewMediaHandler(
	s *service.MediaService,
) *MediaHandler {
	h := &MediaHandler{
		service: s,
	}
	log.Printf("MediaHandler: NewMediaHandler created")
	return h
}

type completeInput struct {
	UploadID string               `json:"upload_id" binding:"required"`
	Parts    []minio.CompletePart `json:"parts" binding:"required"`
}

func (h *MediaHandler) InitUpload(c *gin.Context) {
	log.Println("InitUpload: start")
	media, url, err := h.service.InitUpload(c.Request.Context())
	log.Printf("InitUpload: InitUpload service returned mediaID=%v urlPresent=%t err=%v", func() interface{} {
		if media != nil {
			return media.ID.Hex()
		}
		return "<nil>"
	}(), url != "", err)
	if err != nil {
		log.Printf("InitUpload: error calling service.InitUpload: %v", err)
		c.Error(err) //  giao toàn quyền cho global handler
		return
	}

	log.Printf("InitUpload: sending response for mediaID=%s", media.ID.Hex())
	response.Send(
		c,
		http.StatusCreated,
		"media.upload_initialized",
		gin.H{
			"id":         media.ID.Hex(),
			"upload_url": url,
		},
	)
	log.Println("InitUpload: end")
}

func (h *MediaHandler) CompleteUpload(c *gin.Context) {
	log.Println("CompleteUpload: start")
	mediaID := c.Param("id")
	log.Printf("CompleteUpload: received mediaID=%s", mediaID)

	var input completeInput
	if err := c.ShouldBindJSON(&input); err != nil {
		log.Printf("CompleteUpload: invalid JSON input: %v", err)
		c.Error(appErr.ErrBadRequest.WithErr(err, "media.invalid_complete_data"))
		return
	}
	log.Printf("CompleteUpload: bound input UploadID=%s parts=%d", input.UploadID, len(input.Parts))

	// Truyền thêm input vào service
	if err := h.service.CompleteUpload(c.Request.Context(), mediaID, input.UploadID, input.Parts); err != nil {
		log.Printf("CompleteUpload: service.CompleteUpload error: %v", err)
		c.Error(err)
		return
	}

	log.Printf("CompleteUpload: queued transcoding for mediaID=%s", mediaID)
	response.Send(c, http.StatusOK, "media.queued_transcoding", nil)
	log.Println("CompleteUpload: end")
}

func (h *MediaHandler) GetStatus(c *gin.Context) {
	log.Println("GetStatus: start")
	id := c.Param("id")
	log.Printf("GetStatus: retrieving mediaID=%s", id)
	media, err := h.service.GetByID(c.Request.Context(), id)
	if err != nil {
		log.Printf("GetStatus: service.GetByID error: %v", err)
		c.Error(err)
		return
	}
	log.Printf("GetStatus: got mediaID=%s status=%s", media.ID.Hex(), media.Status)
	response.Send(
		c,
		http.StatusOK,
		"media.status_retrieved",
		gin.H{
			"id":     media.ID.Hex(),
			"status": media.Status, // pending, processing, ready, failed
		},
	)
	log.Println("GetStatus: end")
}

func (h *MediaHandler) Stream(c *gin.Context) {
	// Giả sử bạn lấy ID từ URL: /media/stream/:id
	mediaID := c.Param("id")
	log.Printf("Stream: start mediaID=%s", mediaID)

	// 1. Tìm thông tin media từ DB để lấy bucket/object
	media, err := h.service.GetByID(c.Request.Context(), mediaID)
	if err != nil {
		log.Printf("Stream: GetByID error: %v", err)
		c.Error(err)
		return
	}
	log.Printf("Stream: found media raw.bucket=%s raw.object=%s", media.Raw.Bucket, media.Raw.Object)

	// 2. Lấy stream từ Service
	reader, contentLength, contentType, err := h.service.GetStream(
		c.Request.Context(),
		media.Raw.Bucket,
		media.Raw.Object,
	)
	if err != nil {
		log.Printf("Stream: GetStream error: %v", err)
		c.Error(err)
		return
	}
	defer reader.Close()
	log.Printf("Stream: streaming contentType=%s length=%d", contentType, contentLength)

	// 3. Đẩy stream về client
	extraHeaders := map[string]string{
		"Content-Disposition": "inline",
	}

	c.DataFromReader(http.StatusOK, contentLength, contentType, reader, extraHeaders)
	log.Println("Stream: end")
}

func (h *MediaHandler) InitLargeUpload(c *gin.Context) {
	// 1. Khai báo struct để nhận input từ Client
	var input struct {
		FileSize int64 `json:"size" binding:"required,gt=0"`
	}
	log.Println("InitLargeUpload: start")

	// 2. Bind JSON và kiểm tra lỗi validate
	if err := c.ShouldBindJSON(&input); err != nil {
		log.Printf("InitLargeUpload: invalid input JSON: %v", err)
		c.Error(appErr.ErrBadRequest.WithErr(err, "media.invalid_input"))
		return
	}
	log.Printf("InitLargeUpload: received fileSize=%d", input.FileSize)

	// 3. Gọi Service để lấy danh sách URL
	// fileSize được truyền vào để tính toán chia Part
	res, err := h.service.InitLargeUpload(c.Request.Context(), input.FileSize)
	if err != nil {
		log.Printf("InitLargeUpload: service.InitLargeUpload error: %v", err)
		c.Error(err) // Trình xử lý lỗi tự động lo phần còn lại
		return
	}
	log.Printf("InitLargeUpload: init result ready")

	// 4. Trả về thành công bằng hàm Send tinh gọn
	response.Send(c, http.StatusCreated, "media.init_success", res)
	log.Println("InitLargeUpload: end")
}
