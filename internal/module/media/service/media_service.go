package service

import (
	"context"
	"io"
	"log"
	"math"
	"os"
	"time"

	"chillhub/internal/module/media/model"
	"chillhub/internal/module/media/repository"
	minioshared "chillhub/internal/shared/minio"

	"github.com/minio/minio-go/v7"
	"go.mongodb.org/mongo-driver/bson/primitive"

	appErr "chillhub/internal/shared/error"
)

var mediaFolder = os.Getenv("MEDIA_FOLDER")

type MultiPartUploadResponse struct {
	MediaID  string   `json:"media_id"`
	UploadID string   `json:"upload_id"`
	Parts    []string `json:"parts"`     // Danh sách các URL để FE upload
	PartSize int64    `json:"part_size"` // Kích thước mỗi mảnh (byte)
}

// MediaServiceInterface định nghĩa các hàm chính của MediaService
type MediaServiceInterface interface {
	// InitUpload tạo media record và trả về presigned URL
	InitUpload(ctx context.Context) (*model.Media, string, error)

	CompleteUpload(ctx context.Context, id string) error

	// Streaming Proxy: stream media và ẩn url của MinIO
	GetStream(ctx context.Context, bucket, object string) (io.ReadCloser, int64, string, error)

	// GetByID lấy media theo ID
	GetByID(ctx context.Context, id string) (*model.Media, error)

	InitLargeUpload(ctx context.Context, fileSize int64) (*MultiPartUploadResponse, error)
}

// MediaService implement MediaServiceInterface
type MediaService struct {
	repo       repository.MediaRepository
	transcoder *TranscodingService
	minio      *minioshared.Util
	rawBucket  string // thêm field này
}

// Constructor
func NewMediaService(
	repo repository.MediaRepository,
	transcoder *TranscodingService,
	minio *minioshared.Util,
	rawBucket string, // truyền bucket lúc init
) *MediaService {
	log.Printf("NewMediaService: creating service with rawBucket=%s", rawBucket)
	s := &MediaService{
		repo:       repo,
		transcoder: transcoder,
		minio:      minio,
		rawBucket:  rawBucket,
	}
	log.Println("NewMediaService: created")
	return s
}

// InitUpload tạo record media và trả về presigned PUT URL
func (s *MediaService) InitUpload(
	ctx context.Context,
) (*model.Media, string, error) {
	log.Println("InitUpload: start")
	id := primitive.NewObjectID()
	object := mediaFolder + id.Hex() // không cần extension, FE sẽ gắn extension
	log.Printf("InitUpload: new media id=%s object=%s rawBucket=%s", id.Hex(), object, s.rawBucket)

	if err := s.minio.EnsureBucket(context.Background(), s.rawBucket); err != nil {
		log.Printf("InitUpload: EnsureBucket error: %v", err)
		panic(err) // fail fast, config lỗi thì app không nên chạy
	}
	log.Println("InitUpload: bucket ensured")

	media := &model.Media{
		ID:     id,
		Status: model.StatusDraft, // Mặc định là draft
		Raw: model.RawInfo{
			Bucket: s.rawBucket,
			Object: object,
		},
	}

	// Lưu vào repository
	if err := s.repo.Insert(ctx, media); err != nil {
		log.Printf("InitUpload: repo.Insert error: %v", err)
		return nil, "", err
	}
	log.Printf("InitUpload: media saved id=%s", media.ID.Hex())

	// Tạo presigned PUT URL
	url, err := s.minio.PresignPut(
		ctx,
		s.rawBucket,
		object,
		15*time.Minute,
	)
	if err != nil {
		log.Printf("InitUpload: PresignPut error: %v", err)
		return nil, "", err
	}
	log.Printf("InitUpload: presign url created for media id=%s", media.ID.Hex())

	log.Println("InitUpload: end")
	return media, url, nil
}

func (s *MediaService) CompleteUpload(ctx context.Context, id string, uploadID string, parts []minio.CompletePart) error {
	log.Println("CompleteUpload: start")
	log.Printf("CompleteUpload: mediaID=%s uploadID=%s parts=%d", id, uploadID, len(parts))

	// 1. Kiểm tra Media có tồn tại trong DB không
	media, err := s.GetByID(ctx, id)
	if err != nil {
		log.Printf("CompleteUpload: GetByID error: %v", err)
		return err
	}
	log.Printf("CompleteUpload: fetched media status=%s", media.Status)

	if media.Status != model.StatusDraft {
		log.Printf("CompleteUpload: media status not draft, skipping (status=%s)", media.Status)
		return nil
	}

	// 2. GỌI MINIO ĐỂ GỘP FILE (Quan trọng nhất)
	// Sau lệnh này, file mới thực sự xuất hiện trong bucket "raw"
	log.Printf("CompleteUpload: calling minio.CompleteMultipartUpload bucket=%s object=%s", s.rawBucket, media.Raw.Object)
	err = s.minio.CompleteMultipartUpload(ctx, s.rawBucket, media.Raw.Object, uploadID, parts)
	if err != nil {
		log.Printf("CompleteUpload: MinIO CompleteMultipartUpload error: %v", err)
		return err
	}
	log.Println("CompleteUpload: minio multipart complete succeeded")

	// 3. Cập nhật trạng thái sang Pending
	if err := s.repo.UpdateStatus(ctx, id, model.StatusPending); err != nil {
		log.Printf("CompleteUpload: repo.UpdateStatus error: %v", err)
		return err
	}
	log.Printf("CompleteUpload: media status updated to %s", model.StatusPending)

	// 4. Kích hoạt Transcode chạy ngầm
	// Lúc này Transcoder download file sẽ không còn lỗi "Key does not exist" nữa
	log.Printf("CompleteUpload: starting transcoder for mediaID=%s", media.ID.Hex())
	go s.transcoder.Process(media)

	log.Println("CompleteUpload: end")
	return nil
}

// PresignRawUpload trả về presigned PUT URL cho object
func (s *MediaService) PresignRawUpload(ctx context.Context, object string, expiry time.Duration) (string, error) {
	log.Printf("PresignRawUpload: start object=%s expiry=%v", object, expiry)
	url, err := s.minio.PresignPut(ctx, s.rawBucket, object, expiry)
	if err != nil {
		log.Printf("PresignRawUpload: PresignPut error: %v", err)
		return "", err
	}
	log.Printf("PresignRawUpload: end urlPresent=%t", url != "")
	return url, nil
}

// GetStream stream media từ MinIO
func (s *MediaService) GetStream(ctx context.Context, bucket, object string) (io.ReadCloser, int64, string, error) {
	log.Printf("GetStream: start bucket=%s object=%s", bucket, object)
	reader, length, contentType, err := s.minio.GetObject(ctx, bucket, object)
	if err != nil {
		log.Printf("GetStream: GetObject error: %v", err)
		return nil, 0, "", err
	}
	log.Printf("GetStream: got reader contentType=%s length=%d", contentType, length)
	return reader, length, contentType, nil
}

func (s *MediaService) GetByID(ctx context.Context, id string) (*model.Media, error) {
	log.Printf("GetByID: start id=%s", id)
	objID, err := primitive.ObjectIDFromHex(id)
	if err != nil {
		log.Printf("GetByID: ObjectIDFromHex error: %v", err)
		return nil, appErr.ErrBadRequest.WithErr(err)
	}
	log.Printf("GetByID: parsed objectID=%s", objID.Hex())

	// Gọi vào repository để lấy data
	media, err := s.repo.FindByID(ctx, objID)
	if err != nil {
		log.Printf("GetByID: repo.FindByID error: %v", err)
		return nil, err
	}
	log.Printf("GetByID: success mediaID=%s status=%s", media.ID.Hex(), media.Status)
	return media, nil
}

func (s *MediaService) InitLargeUpload(ctx context.Context, fileSize int64) (*MultiPartUploadResponse, error) {
	log.Println("InitLargeUpload: start")
	id := primitive.NewObjectID()
	object := mediaFolder + id.Hex()
	log.Printf("InitLargeUpload: id=%s object=%s fileSize=%d", id.Hex(), object, fileSize)

	// 1. Khởi tạo phiên upload trên MinIO để lấy UploadID
	uploadID, err := s.minio.NewMultipartUpload(ctx, s.rawBucket, object)
	if err != nil {
		log.Printf("InitLargeUpload: NewMultipartUpload error: %v", err)
		return nil, err
	}
	log.Printf("InitLargeUpload: created uploadID=%s", uploadID)

	// 2. Tính toán số lượng mảnh (Parts)
	// Giả sử giới hạn là 200MB, ta chọn mỗi mảnh 50MB cho an toàn
	const maxPartSize = 50 * 1024 * 1024 // 50MB
	numParts := int(math.Ceil(float64(fileSize) / float64(maxPartSize)))
	log.Printf("InitLargeUpload: numParts=%d partSize=%d", numParts, maxPartSize)

	var partURLs []string
	for i := 1; i <= numParts; i++ {
		// Tạo Presigned URL cho từng Part
		url, err := s.minio.PresignUploadPart(ctx, s.rawBucket, object, uploadID, i, 1*time.Hour)
		if err != nil {
			log.Printf("InitLargeUpload: PresignUploadPart error part=%d: %v", i, err)
			return nil, err
		}
		log.Printf("InitLargeUpload: presigned part %d url created", i)
		partURLs = append(partURLs, url)
	}

	// 3. Lưu thông tin sơ bộ vào DB (Status Draft)
	media := &model.Media{
		ID:     id,
		Status: model.StatusDraft,
		Raw: model.RawInfo{
			Bucket: s.rawBucket,
			Object: object,
		},
	}
	if err := s.repo.Insert(ctx, media); err != nil {
		log.Printf("InitLargeUpload: repo.Insert error: %v", err)
		return nil, err
	}
	log.Printf("InitLargeUpload: media saved id=%s", media.ID.Hex())

	log.Println("InitLargeUpload: end")
	return &MultiPartUploadResponse{
		MediaID:  id.Hex(),
		UploadID: uploadID,
		Parts:    partURLs,
		PartSize: maxPartSize,
	}, nil
}
