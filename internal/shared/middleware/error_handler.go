package middleware

import (
	"errors"
	"net/http"

	"chillhub/internal/shared/error"
	"chillhub/internal/shared/response"

	"github.com/gin-gonic/gin"
)

func ErrorHandler(debug bool) gin.HandlerFunc {
    return func(c *gin.Context) {
        c.Next()

        if len(c.Errors) == 0 {
            return
        }

        err := c.Errors.Last().Err
        var appErr *error.AppError

        status := http.StatusInternalServerError
        message := "internal.server_error"
        var trace string

        if errors.As(err, &appErr) {
            // Lỗi nghiệp vụ
            status = appErr.Status
            message = appErr.Message
            if debug && appErr.Err != nil {
                trace = appErr.Err.Error()
            }
        } else {
            // Lỗi hệ thống không xác định
            if debug {
                trace = err.Error()
            }
        }

        // Tạo ErrorBody gọn nhẹ
        var errBody *response.ErrorBody
        if trace != "" {
            errBody = &response.ErrorBody{Trace: trace}
        }

        c.AbortWithStatusJSON(status, response.Envelope{
            Success: false,
            Status:  status,
            Message: message,
            Error:   errBody,
        })
    }
}
