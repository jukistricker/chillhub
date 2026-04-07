using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace chillhub.Utils;

public static class DataUtil
{
    // Thiết lập Strict Mode: Khớp chính xác 1-1
    private static readonly JsonSerializerOptions _options = new()
    {
        // Tắt không phân biệt hoa thường (Mắt nhìn UserId thì phải đúng UserId)
        PropertyNameCaseInsensitive = false,

        // Giữ nguyên tên thuộc tính như trong Code C# khi xuất ra JSON
        PropertyNamingPolicy = null,

        // Tối ưu thêm: Bỏ qua các trường null để chuỗi JSON gọn nhất
        //DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Parse từ chuỗi (Khớp chính xác hoa thường)
    /// </summary>
    public static T? JsonToObject<T>(string? json) =>
        string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json, _options);

    /// <summary>
    /// Parse từ byte array (Hiệu năng cao, khớp chính xác)
    /// </summary>
    public static T? ByteToObject<T>(byte[]? data) =>
        (data == null || data.Length == 0) ? default : JsonSerializer.Deserialize<T>(data, _options);

    /// <summary>
    /// Cách 3: Parse từ RedisValue (Tối ưu riêng cho StackExchange.Redis)
    ///</summary>
    /// <summary>
    /// Cách 3: Parse từ RedisValue (Tốc độ tối đa cho StackExchange.Redis)
    /// </summary>
    public static T? RedisValueToObject<T>(RedisValue value)
    {
        // Kiểm tra RedisValue có dữ liệu hay không
        if (value.IsNull || !value.HasValue)
            return default;
        
        // 1. Ép kiểu sang ReadOnlyMemory (Có sẵn từ StackExchange.Redis)
        // 2. Truy cập thuộc tính .Span để lấy vùng nhớ thô truyền vào Deserialize
        ReadOnlySpan<byte> span = ((ReadOnlyMemory<byte>)value).Span;

        return JsonSerializer.Deserialize<T>(span, _options);
    }



    /// <summary>
    /// Chuyển đổi object ra JSON (Giữ nguyên định dạng PascalCase/snake_case của Class)
    /// </summary>
    public static string ObjectToJson(object? obj)
    {
        if (obj == null) return string.Empty;
        return JsonSerializer.Serialize(obj, _options);
    }

    /// <summary>
    /// Mapping giữa 2 object (Dùng JSON làm trung gian, khớp chính xác thuộc tính)
    /// </summary>
    public static T? Map<T>(object? source)
    {
        if (source == null) return default;
        var json = JsonSerializer.Serialize(source, _options);
        return JsonSerializer.Deserialize<T>(json, _options);
    }
    

}
