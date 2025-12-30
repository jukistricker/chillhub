package minio

import (
	"context"
	"fmt"
	"io"
	"mime/multipart"
	"net/http"
	"net/url"
	"os"
	"path/filepath"
	"strconv"
	"time"

	appErr "chillhub/internal/shared/error"

	"github.com/minio/minio-go/v7"
)

type Util struct {
	storage *Client
}

func NewUtil(client *Client) *Util {
	return &Util{storage: client}
}

func (u *Util) Upload(
	ctx context.Context,
	file *multipart.FileHeader,
	bucket string,
	basePath string,
) (*ObjectInfo, error) {

	src, err := file.Open()
	if err != nil {
		return nil, appErr.New(
			http.StatusInternalServerError,
			"file.open.failed",
		)
	}
	defer src.Close()

	object := buildObjectPath(basePath, file.Filename)

	_, err = u.storage.cli.PutObject(
		ctx,
		bucket,
		object,
		src,
		file.Size,
		minio.PutObjectOptions{
			ContentType: file.Header.Get("Content-Type"),
		},
	)
	if err != nil {
		return nil, appErr.ErrInternal.WithErr(
			err,
			"minio.upload.failed",
		)
	}

	return &ObjectInfo{
		Bucket: bucket,
		Object: object,
		URL:    u.storage.baseURL + "/" + bucket + "/" + object,
	}, nil
}

func (u *Util) Delete(
	ctx context.Context,
	bucket string,
	object string,
) error {

	err := u.storage.cli.RemoveObject(
		ctx,
		bucket,
		object,
		minio.RemoveObjectOptions{},
	)
	if err != nil {
		return appErr.ErrInternal.WithErr(
			err,
			"minio.delete.failed",
		)
	}

	return nil
}

func (u *Util) PresignGet(
	ctx context.Context,
	bucket string,
	object string,
	expiry time.Duration,
) (string, error) {

	url, err := u.storage.cli.PresignedGetObject(
		ctx,
		bucket,
		object,
		expiry,
		nil,
	)
	if err != nil {
		return "", appErr.ErrInternal.WithErr(
			err,
			"minio.presign.get.failed",
		)
	}

	return url.String(), nil
}

func (u *Util) PresignPut(
	ctx context.Context,
	bucket string,
	object string,
	expiry time.Duration,
) (string, error) {

	print(bucket)
	url, err := u.storage.cli.PresignedPutObject(
		ctx,
		bucket,
		object,
		expiry,
	)
	if err != nil {
		print("error: ",err)
		return "", appErr.ErrInternal.WithErr(
			err,
			"minio.presign.put.failed",
		)
	}

	return url.String(), nil
}


func (u *Util) EnsureBucket(
	ctx context.Context,
	bucket string,
) error {

	exists, err := u.storage.cli.BucketExists(ctx, bucket)
	if err != nil {
		return appErr.ErrInternal.WithErr(err, "minio.bucket.check.failed")
	}

	if exists {
		return nil
	}

	return nil
}


func (u *Util) GetObject(ctx context.Context, bucket, object string) (io.ReadCloser, int64, string, error) {
    obj, err := u.storage.cli.GetObject(ctx, bucket, object, minio.GetObjectOptions{})
    if err != nil {
        return nil, 0, "", appErr.ErrNotFound.WithErr(
			err,
			"minio.object.not_found",
		)
    }

    info, err := obj.Stat()
    if err != nil {
        return nil, 0, "", appErr.ErrInternal.WithErr(
			err,
			"minio.object.stat_failed",
		)
    }

    return obj, info.Size, info.ContentType, nil
}


// UploadFolder tải tất cả file trong folderPath lên MinIO dưới prefix
func (u *Util) UploadFolder(ctx context.Context, bucket, prefix, folderPath string, excludeFiles ...string) error {
	files, err := os.ReadDir(folderPath)
	if err != nil {
		return err
	}

	// Tạo map để kiểm tra file loại trừ
	excludeMap := make(map[string]bool)
	for _, name := range excludeFiles {
		excludeMap[name] = true
	}

	for _, f := range files {
		// Bỏ qua nếu là folder hoặc nằm trong danh sách loại trừ
		if f.IsDir() || excludeMap[f.Name()] {
			continue
		}

		// Chỉ upload index.m3u8 và các file .ts
		ext := filepath.Ext(f.Name())
		if ext != ".m3u8" && ext != ".ts" {
			continue
		}

		targetObject := fmt.Sprintf("%s/%s", prefix, f.Name())
		sourceFile := filepath.Join(folderPath, f.Name())

		// Xác định Content-Type cho HLS
		contentType := "application/x-mpegURL"
		if ext == ".ts" {
			contentType = "video/MP2T"
		}

		_, err := u.storage.cli.FPutObject(ctx, bucket, targetObject, sourceFile, minio.PutObjectOptions{
			ContentType: contentType,
		})
		if err != nil {
			return err
		}
	}
	return nil
}


// FGetObject tải một object từ MinIO về file local
func (u *Util) FGetObject(ctx context.Context, bucket, object, filePath string) error {
    // Gọi trực tiếp từ minio-go client
    return u.storage.cli.FGetObject(ctx, bucket, object, filePath, minio.GetObjectOptions{})
}


// Khởi tạo một phiên upload mới, trả về UploadID
func (u *Util) NewMultipartUpload(ctx context.Context, bucket, object string) (string, error) {
	core := minio.Core{Client: u.storage.cli}
	// Khởi tạo phiên upload với MinIO
	uploadID, err := core.NewMultipartUpload(ctx, bucket, object, minio.PutObjectOptions{})
	if err != nil {
		return "", err
	}
	return uploadID, nil
}

// Tạo URL cho từng mảnh (Part) của file
func (u *Util) PresignUploadPart(ctx context.Context, bucket, object, uploadID string, partNumber int, expiry time.Duration) (string, error) {
	// Query params bắt buộc để MinIO nhận diện mảnh của file
	values := make(url.Values)
	values.Set("uploadId", uploadID)
	values.Set("partNumber", strconv.Itoa(partNumber))

	// Tạo Presigned URL cho phương thức PUT
	uPart, err := u.storage.cli.Presign(ctx, "PUT", bucket, object, expiry, values)
	if err != nil {
		return "", err
	}
	return uPart.String(), nil
}

// Hoàn tất việc ghép các mảnh lại thành file hoàn chỉnh
func (u *Util) CompleteMultipartUpload(ctx context.Context, bucket, object, uploadID string, parts []minio.CompletePart) error {
	core := minio.Core{Client: u.storage.cli}
	_, err := core.CompleteMultipartUpload(ctx, bucket, object, uploadID, parts, minio.PutObjectOptions{})
	return err
}