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
	print("rawBucket trong service: ", rawBucket)
	return &MediaService{
		repo:       repo,
		transcoder: transcoder,
		minio:      minio,
		rawBucket:  rawBucket,
	}
}

// InitUpload tạo record media và trả về presigned PUT URL
func (s *MediaService) InitUpload(
	ctx context.Context,
) (*model.Media, string, error) {

	id := primitive.NewObjectID()
	object := mediaFolder + id.Hex() // không cần extension, FE sẽ gắn extension

	print("Tại InitUpload: ",s.rawBucket)
	if err := s.minio.EnsureBucket(context.Background(), s.rawBucket); err != nil {
		panic(err) // fail fast, config lỗi thì app không nên chạy
	}

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
		return nil, "", err
	}

	// Tạo presigned PUT URL
	url, err := s.minio.PresignPut(
		ctx,
		s.rawBucket,
		object,
		15*time.Minute,
	)
	
	if err != nil {
		return nil, "", err
	}

	return media, url, nil
}

func (s *MediaService) CompleteUpload(ctx context.Context, id string) error {
    // 1. Kiểm tra Media có tồn tại không
    media, err := s.GetByID(ctx, id)
    if err != nil {
        return err
    }

    // 2. Kiểm tra nếu đã upload hoặc đang xử lý rồi thì không chạy lại
    if media.Status != model.StatusDraft {
        return nil 
    }

    // 3. Cập nhật trạng thái sang Pending (Chờ xử lý)
    // Bạn nên dùng UpdateStatus thay vì Insert
    if err := s.repo.UpdateStatus(ctx, id, model.StatusPending); err != nil {
        return err
    }

    // 4. Kích hoạt Transcode chạy ngầm
    // CHÚ Ý: Ở bản cmd/worker, đoạn này sẽ là đẩy message vào Queue.
    // Hiện tại chạy chung 1 app thì dùng goroutine.
    go s.transcoder.Process(media)

    return nil
}


// PresignRawUpload trả về presigned PUT URL cho object
func (s *MediaService) PresignRawUpload(ctx context.Context, object string, expiry time.Duration) (string, error) {
	return s.minio.PresignPut(ctx, s.rawBucket, object, expiry)
}

// GetStream stream media từ MinIO
func (s *MediaService) GetStream(ctx context.Context, bucket, object string) (io.ReadCloser, int64, string, error) {
    // Gọi util để lấy object
    return s.minio.GetObject(ctx, bucket, object)
}

func (s *MediaService) GetByID(ctx context.Context, id string) (*model.Media, error) {
    objID, err := primitive.ObjectIDFromHex(id)
    if err != nil {
        // if appErr.GetStatus(err) == http.StatusBadRequest {
        //     return nil, appErr.ErrBadRequest.WithErr(err, "media.invalid_id")
        // }
        
        // Trả về lỗi 500 mẫu, NHƯNG đính kèm lỗi thật từ Mongo để GEH log ra
        return nil, appErr.ErrBadRequest.WithErr(err)
    }

    // Gọi vào repository để lấy data
    return s.repo.FindByID(ctx, objID)
}


func (s *MediaService) InitLargeUpload(ctx context.Context, fileSize int64) (*MultiPartUploadResponse, error) {
	id := primitive.NewObjectID()
	object := mediaFolder + id.Hex()

	log.Println("id:", id)
	log.Println("object:", object)

	// 1. Khởi tạo phiên upload trên MinIO để lấy UploadID
	uploadID, err := s.minio.NewMultipartUpload(ctx, s.rawBucket, object)
	if err != nil {
		return nil, err
	}

	// 2. Tính toán số lượng mảnh (Parts)
	// Giả sử giới hạn là 200MB, ta chọn mỗi mảnh 50MB cho an toàn
	const maxPartSize = 50 * 1024 * 1024 // 50MB
	numParts := int(math.Ceil(float64(fileSize) / float64(maxPartSize)))

	var partURLs []string
	for i := 1; i <= numParts; i++ {
		// Tạo Presigned URL cho từng Part
		url, err := s.minio.PresignUploadPart(ctx, s.rawBucket, object, uploadID, i, 1*time.Hour)
		if err != nil {
			return nil, err
		}
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
	s.repo.Insert(ctx, media)

	return &MultiPartUploadResponse{
		MediaID:  id.Hex(),
		UploadID: uploadID,
		Parts:    partURLs,
		PartSize: maxPartSize,
	}, nil
}