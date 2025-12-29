package config

import (
	"log"
	"os"

	"github.com/joho/godotenv"
)

type Config struct {
	Port string

	MongoURI string
	MongoDB  string

	MinioEndpoint string
	MinioKey      string
	MinioSecret   string

	MinioUseSSL  bool
	MinioBaseURL string

	RawBucket string
	HLSBucket string
}


func Load() Config {
	err := godotenv.Load("../../.env") // Adjust path based on where you run the binary
    if err != nil {
        log.Fatal("Error loading .env file")
    }

	useSSL := os.Getenv("MINIO_USE_SSL") == "true"
	

	cfg := Config{
		Port:           os.Getenv("APP_PORT"),
		MongoURI:       os.Getenv("MONGO_URI"),
		MongoDB:        os.Getenv("MONGO_DB"),
		MinioEndpoint:  os.Getenv("MINIO_ENDPOINT"),
		MinioKey:       os.Getenv("MINIO_ACCESS_KEY"),
		MinioSecret:   os.Getenv("MINIO_SECRET_KEY"),
		MinioUseSSL:   useSSL,
		MinioBaseURL:  os.Getenv("MINIO_BASE_URL"),
		RawBucket:     os.Getenv("MINIO_BUCKET_RAW"),
		HLSBucket:     os.Getenv("MINIO_BUCKET_HLS"),
	}
	log.Printf("APP_PORT: %s", cfg.Port)

	if cfg.Port == "" {
		log.Fatal("APP_PORT is required")
	}

	if cfg.MinioBaseURL == "" {
		log.Fatal("MINIO_BASE_URL is required")
	}

	return cfg
}

