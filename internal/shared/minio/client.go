package minio

import (
	"net"
	"net/http"
	"time"

	"github.com/minio/minio-go/v7"
	"github.com/minio/minio-go/v7/pkg/credentials"
)

type Client struct {
	cli     *minio.Client
	baseURL string
}

func NewClient(
	endpoint string,
	accessKey string,
	secretKey string,
	useSSL bool,
	baseURL string,
) (*Client, error) {

	// Tùy chỉnh Transport để tăng sức tải
	transport := &http.Transport{
        Proxy: http.ProxyFromEnvironment,
        DialContext: (&net.Dialer{
            Timeout:   15 * time.Second, // Giảm timeout xuống để giải phóng pool nhanh hơn
            KeepAlive: 30 * time.Second,
        }).DialContext,
        
        // Thông số cho máy tính phổ thông
        MaxIdleConns:          100, // Tổng kết nối trong pool nên để khoảng 100
        MaxIdleConnsPerHost:   100, // Cho phép tối đa 100 kết nối chờ tới MinIO
        
        IdleConnTimeout:       60 * time.Second,
        TLSHandshakeTimeout:   5 * time.Second,
        ExpectContinueTimeout: 1 * time.Second,
        
        // Giới hạn số lượng kết nối tối đa (tránh tràn RAM/CPU của PC)
        MaxConnsPerHost:       200, 
    }

	cli, err := minio.New(endpoint, &minio.Options{
		Creds:     credentials.NewStaticV4(accessKey, secretKey, ""),
		Secure:    useSSL,
		Transport: transport, // Gắn cấu hình Transport
	})
	if err != nil {
		return nil, err
	}

	return &Client{
		cli:     cli,
		baseURL: baseURL,
	}, nil
}

func (c *Client) Raw() *minio.Client {
	return c.cli
}
