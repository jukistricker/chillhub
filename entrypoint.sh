#!/bin/bash

CERT_DIR="/certs"
DOMAIN="localhost"

if [ ! -f "$CERT_DIR/aspnetapp.pfx" ]; then
    echo "--- Đang tạo Self-signed Certificate cho ASP.NET Core ---"
    
    openssl req -x509 -nodes -days 365 -newkey rsa:2048 \
        -keyout "$CERT_DIR/key.pem" \
        -out "$CERT_DIR/cert.pem" \
        -subj "/C=VN/ST=Hanoi/L=Hanoi/O=ChillHub/CN=$DOMAIN"

    openssl pkcs12 -export -out "$CERT_DIR/aspnetapp.pfx" \
        -inkey "$CERT_DIR/key.pem" \
        -in "$CERT_DIR/cert.pem" \
        -password pass:password
    
    chmod 644 "$CERT_DIR/aspnetapp.pfx"
    
    echo "--- Đã tạo cert thành công ---"
else
    echo "--- Cert đã tồn tại, bỏ qua bước tạo ---"
fi