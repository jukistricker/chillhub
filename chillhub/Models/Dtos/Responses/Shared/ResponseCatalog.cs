namespace chillhub.Models.Dtos.Responses.Shared;

public sealed class ResponseCatalog
{
    public int Status { get; }
    public string DefaultMessage { get; }

    private ResponseCatalog(int status, string defaultMessage)
    {
        Status = status;
        DefaultMessage = defaultMessage;
    }

    // ===== 2xx Success =====
    public static readonly ResponseCatalog Success = new(200, "success");
    public static readonly ResponseCatalog Created = new(201, "created");

    // ===== 4xx Client Errors (Common) =====
    public static readonly ResponseCatalog BadRequest = new(400, "bad_request");
    public static readonly ResponseCatalog Unauthorized = new(401, "unauthorized");
    public static readonly ResponseCatalog Forbidden = new(403, "forbidden");
    public static readonly ResponseCatalog NotFound = new(404, "not_found");
    public static readonly ResponseCatalog MethodNotAllowed = new(405, "method_not_allowed");
    public static readonly ResponseCatalog NotAcceptable = new(406, "not_acceptable");
    public static readonly ResponseCatalog RequestTimeout = new(408, "request_timeout");
    public static readonly ResponseCatalog Conflict = new(409, "conflict");
    public static readonly ResponseCatalog Gone = new(410, "gone");
    public static readonly ResponseCatalog PayloadTooLarge = new(413, "payload_too_large");
    public static readonly ResponseCatalog UnsupportedMediaType = new(415, "unsupported_media_type");
    public static readonly ResponseCatalog UnprocessableEntity = new(422, "validation_failed");
    public static readonly ResponseCatalog TooManyRequests = new(429, "too_many_requests");

    // ===== 5xx Server Errors =====
    public static readonly ResponseCatalog Internal = new(500, "internal_error");
    public static readonly ResponseCatalog NotImplemented = new(501, "not_implemented");
    public static readonly ResponseCatalog BadGateway = new(502, "bad_gateway");
    public static readonly ResponseCatalog ServiceUnavailable = new(503, "service_unavailable");
    public static readonly ResponseCatalog GatewayTimeout = new(504, "gateway_timeout");

    // ===== Custom Business Logic Codes (Optional) =====
    // Có thể thêm các mã lỗi đặc thù cho nghiệp vụ tại đây
    public static readonly ResponseCatalog AccountLocked = new(423, "account_locked");
}