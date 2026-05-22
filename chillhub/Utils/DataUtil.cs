using StackExchange.Redis;
using System;
using System.Text.Json;

namespace chillhub.Utils;

public static class DataUtil
{
    private static readonly JsonSerializerOptions _options = new();

    public static T? JsonToObject<T>(string? json) =>
        string.IsNullOrWhiteSpace(json) ? default : JsonSerializer.Deserialize<T>(json, _options);

    public static T? ByteToObject<T>(byte[]? data) =>
        (data == null || data.Length == 0) ? default : JsonSerializer.Deserialize<T>(data, _options);

    public static T? RedisValueToObject<T>(RedisValue value)
    {
        if (value.IsNull || !value.HasValue)
            return default;

        // Chuyển đổi trực tiếp sang ReadOnlySpan<byte> để Deserialize không cần giải nén chuỗi
        ReadOnlySpan<byte> span = ((ReadOnlyMemory<byte>)value).Span;
        return JsonSerializer.Deserialize<T>(span, _options);
    }

    public static string ObjectToJson(object? obj)
    {
        if (obj == null) return string.Empty;
        return JsonSerializer.Serialize(obj, _options);
    }

    public static T? Map<T>(object? source)
    {
        if (source == null) return default;
        var json = JsonSerializer.Serialize(source, _options);
        return JsonSerializer.Deserialize<T>(json, _options);
    }
}