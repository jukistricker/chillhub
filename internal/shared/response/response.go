package response

import "github.com/gin-gonic/gin"

type Envelope struct {
	Success bool       `json:"success"`
	Status  int        `json:"status,omitempty"`
	Message string     `json:"message"`
	Data    any        `json:"data,omitempty"`
	Error   *ErrorBody `json:"error,omitempty"`
}

type ErrorBody struct {
	Trace	string 	   `json:"err,omitempty"`
}

func Send(c *gin.Context,status int, message string,  data any) {
	c.JSON(status, Envelope{
		Success: status >= 200 && status < 400, // Tự động xác định success dựa trên status
		Status:  status,
		Message: message,
		Data:    data,
	})
}