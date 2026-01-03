package service

import (
	"chillhub/internal/module/media/model"
	"chillhub/internal/module/media/repository"
	minioshared "chillhub/internal/shared/minio"
	"context"
	"fmt"
	"log"
	"os"
	"os/exec"
	"path/filepath"
)

type TranscodingService struct {
    minio *minioshared.Util
    repo  repository.MediaRepository
}

func NewTranscodingService(m *minioshared.Util, r repository.MediaRepository) *TranscodingService {
    return &TranscodingService{minio: m, repo: r}
}

func (t *TranscodingService) Process(media *model.Media) {
    ctx := context.Background()
    mediaID := media.ID.Hex()

    log.Printf("[transcode] start processing mediaID=%s raw=%s/%s", mediaID, media.Raw.Bucket, media.Raw.Object)

    // 1. Cập nhật DB sang trạng thái đang xử lý
    if err := t.repo.UpdateStatus(ctx, mediaID, model.StatusProcessing); err != nil {
        log.Printf("[transcode] warn: UpdateStatus -> Processing failed for mediaID=%s: %v", mediaID, err)
    } else {
        log.Printf("[transcode] status updated -> processing mediaID=%s", mediaID)
    }

    // 2. Tạo thư mục làm việc tạm thời
    workDir := filepath.Join(os.TempDir(), "transcode", mediaID)
    if err := os.MkdirAll(workDir, 0755); err != nil {
        log.Printf("[transcode] error creating workDir=%s: %v", workDir, err)
        _ = t.repo.UpdateStatus(ctx, mediaID, model.StatusFailed)
        return
    }
    log.Printf("[transcode] workDir created: %s", workDir)
    defer func() {
        if err := os.RemoveAll(workDir); err != nil {
            log.Printf("[transcode] warn: failed to remove workDir=%s: %v", workDir, err)
        } else {
            log.Printf("[transcode] workDir removed: %s", workDir)
        }
    }()

    // Lấy hậu tố (extension) của file gốc từ MinIO (vd: .mp4, .mov)
    ext := filepath.Ext(media.Raw.Object)
    if ext == "" {
        ext = ".mp4" // mặc định nếu không lấy được
    }
    log.Printf("[transcode] detected extension=%s", ext)

    // Đặt tên file tạm là [mediaID]_raw.[extension] để không bao giờ trùng
    tempInputName := fmt.Sprintf("%s_raw%s", mediaID, ext)
    inputPath := filepath.Join(workDir, tempInputName)
    log.Printf("[transcode] temp input will be: %s", inputPath)

    // 3. Download file gốc từ MinIO về máy local
    log.Printf("[transcode] downloading from bucket=%s object=%s to %s", media.Raw.Bucket, media.Raw.Object, inputPath)
    if err := t.minio.FGetObject(ctx, media.Raw.Bucket, media.Raw.Object, inputPath); err != nil {
        log.Printf("[transcode] download failed for mediaID=%s: %v", mediaID, err)
        _ = t.repo.UpdateStatus(ctx, mediaID, model.StatusFailed)
        return
    }
    log.Printf("[transcode] download completed: %s", inputPath)

    // 4. FFmpeg: Input -> HLS
    outputPath := filepath.Join(workDir, "index.m3u8")
    cmd := exec.Command("ffmpeg", "-i", inputPath,
        "-codec:v", "libx264", "-codec:a", "aac",
        "-hls_time", "6",
        "-hls_playlist_type", "vod",
        // File phân đoạn cũng dùng mediaID làm tiền tố cho chắc chắn
        "-hls_segment_filename", filepath.Join(workDir, mediaID+"_%03d.ts"),
        outputPath,
    )
    log.Printf("[transcode] running ffmpeg for mediaID=%s args=%v", mediaID, cmd.Args)

    out, err := cmd.CombinedOutput()
    if err != nil {
        log.Printf("[transcode] ffmpeg failed for mediaID=%s: %v; output: %s", mediaID, err, string(out))
        _ = t.repo.UpdateStatus(ctx, mediaID, model.StatusFailed)
        return
    }
    log.Printf("[transcode] ffmpeg finished for mediaID=%s; output length=%d", mediaID, len(out))

    // 5. Upload folder nhưng loại trừ file tạm [tempInputName]
    // Liệt kê files trước khi upload để debug
    entries, err := os.ReadDir(workDir)
    if err != nil {
        log.Printf("[transcode] warn: cannot read workDir=%s: %v", workDir, err)
    } else {
        names := make([]string, 0, len(entries))
        for _, e := range entries {
            names = append(names, e.Name())
        }
        log.Printf("[transcode] workDir contents before upload: %v", names)
    }

    log.Printf("[transcode] uploading processed files to bucket=processed prefix=%s (excluding %s)", mediaID, tempInputName)
    if err := t.minio.UploadFolder(ctx, "processed", mediaID, workDir, tempInputName); err != nil {
        log.Printf("[transcode] upload folder failed for mediaID=%s: %v", mediaID, err)
        _ = t.repo.UpdateStatus(ctx, mediaID, model.StatusFailed)
        return
    }
    log.Printf("[transcode] upload completed for mediaID=%s", mediaID)

    // 6. Hoàn tất
    if err := t.repo.UpdateStatus(ctx, mediaID, model.StatusReady); err != nil {
        log.Printf("[transcode] warn: UpdateStatus -> Ready failed for mediaID=%s: %v", mediaID, err)
    } else {
        log.Printf("[transcode] processing finished successfully mediaID=%s", mediaID)
    }
}
