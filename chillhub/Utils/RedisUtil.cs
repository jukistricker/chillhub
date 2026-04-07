using StackExchange.Redis;
using System.Collections.Concurrent;
using System.Globalization;
using System.Reflection;
using System.Text.Json;

namespace chillhub.Utils;

public static class RedisUtil
{
    // Cache lại các Property để tránh dùng Reflection quá nhiều gây chậm (Performance cực quan trọng cho Session)
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();

    // Tận dụng DataUtil._options đã cấu hình Strict Mode từ trước
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = false,
        PropertyNamingPolicy = null
    };

    /// <summary>
    /// Lưu nhiều field vào Hash bằng cách dùng trực tiếp RedisValue để tránh boxing chuỗi
    /// </summary>
    public static async Task SetHashAsync(
        IDatabase db,
        string key,
        IEnumerable<KeyValuePair<string, object>> values,
        TimeSpan? expiry = null)
    {
        // Tránh dùng Select().ToArray() để giảm allocation nếu có thể
        var entries = values.Select(kv => new HashEntry(kv.Key, Serialize(kv.Value))).ToArray();

        await db.HashSetAsync(key, entries);

        if (expiry.HasValue)
            await db.KeyExpireAsync(key, expiry.Value);
    }

    /// <summary>
    /// Lấy 1 field và parse bằng ReadOnlySpan để đạt hiệu năng tối đa
    /// </summary>
    public static async Task<T?> GetFieldAsync<T>(IDatabase db, string key, string field)
    {
        var val = await db.HashGetAsync(key, field);
        if (val.IsNull) return default;

        return Deserialize<T>(val);
    }

    /// <summary>
    /// Tối ưu Serialize: Giảm thiểu ToString() thủ công, tận dụng Implicit conversion của StackExchange.Redis
    /// </summary>
    private static RedisValue Serialize(object? obj)
    {
        if (obj == null) return RedisValue.Null;

        return obj switch
        {
            string s => s,
            int i => i,
            long l => l,
            bool b => b,
            double d => d,
            byte[] bytes => bytes,
            Guid g => g.ToByteArray(),
            DateTime dt => dt.ToBinary(),
            // DateTimeOffset: Lưu dạng chuỗi ISO 8601 ("o") để giữ nguyên múi giờ và độ chính xác
            DateTimeOffset dto => dto.ToString("o"),
            _ => JsonSerializer.Serialize(obj, Options)
        };
    }

    public static async Task DeleteFieldsAsync(IDatabase db, string key, params string[] fields)
    {
        if (fields.Length == 0) return;
        await db.HashDeleteAsync(key, Array.ConvertAll(fields, f => (RedisValue)f));
    }

    public static async Task<bool> FieldExistsAsync(IDatabase db, string key, string field)
        => await db.HashExistsAsync(key, field);

    /// <summary>
    /// Set toàn bộ Object vào Redis Hash. Tự động map Property Name thành Field.
    /// </summary>
    public static async Task SetObjectToHashAsync<T>(
        IDatabase db,
        string key,
        T obj,
        TimeSpan? expiry = null) where T : class
    {

        // Lấy danh sách Property từ Cache
        var properties = PropertyCache.GetOrAdd(typeof(T), t => t.GetProperties());

        var entries = new HashEntry[properties.Length];

        for (int i = 0; i < properties.Length; i++)
        {
            var prop = properties[i];
            var value = prop.GetValue(obj);
            // Tận dụng hàm Serialize có sẵn của bạn để xử lý String, Int, List, v.v.
            entries[i] = new HashEntry(prop.Name, Serialize(value));
        }

        await db.HashSetAsync(key, entries);

        if (expiry.HasValue)
            await db.KeyExpireAsync(key, expiry.Value);
    }

    /// <summary>
    /// Get toàn bộ Object từ Redis Hash
    /// </summary>
    public static async Task<T?> GetObjectFromHashAsync<T>(IDatabase db, string key) where T : class, new()
    {
        var entries = await db.HashGetAllAsync(key);
        if (entries.Length == 0) return null;

        var obj = new T();
        var properties = PropertyCache.GetOrAdd(typeof(T), t => t.GetProperties());

        // Tối ưu: Dùng dictionary để lookup nhanh hơn
        var dict = entries.ToDictionary(e => e.Name.ToString(), e => e.Value);

        foreach (var prop in properties)
        {
            if (dict.TryGetValue(prop.Name, out var redisValue))
            {
                // GỌI THẲNG hàm hỗ trợ không dùng Reflection Invoke
                var value = Deserialize(redisValue, prop.PropertyType);
                prop.SetValue(obj, value);
            }
        }

        return obj;
    }

    // 1. Hàm Deserialize Non-generic (Core Logic)
    private static object? Deserialize(RedisValue val, Type type)
    {
        if (val.IsNull) return null;

        if (type == typeof(string)) return val.ToString();
        if (type == typeof(int)) return (int)val;
        if (type == typeof(long)) return (long)val;
        if (type == typeof(bool)) return (bool)val;
        if (type == typeof(double)) return (double)val;
        if (type == typeof(Guid)) return new Guid((byte[])val!);
        if (type == typeof(DateTime)) return DateTime.FromBinary((long)val);

        if (type == typeof(DateTimeOffset))
            return DateTimeOffset.Parse(val.ToString(), null, DateTimeStyles.RoundtripKind);

        // Xử lý JSON cho các kiểu phức tạp (List, Object lồng)
        ReadOnlySpan<byte> span = ((ReadOnlyMemory<byte>)val).Span;
        return JsonSerializer.Deserialize(span, type, Options);
    }

    // 2. Hàm Deserialize Generic (Vẫn giữ để dùng cho các chỗ khác như GetFieldAsync)
    private static T Deserialize<T>(RedisValue val)
    {
        return (T)Deserialize(val, typeof(T))!;
    }

    /// <summary>
    /// Set toàn bộ object thành JSON Blob (Redis String)
    /// </summary>
    public static async Task SetObjectAsJsonAsync<T>(
        IDatabase db,
        string key,
        T obj,
        TimeSpan expiry)
    {
        var bytes = JsonSerializer.SerializeToUtf8Bytes(obj, Options);

        await db.StringSetAsync(
            key,
            bytes,
            expiry
        );
    }

    /// <summary>
    /// Get toàn bộ object từ JSON Blob (Redis String)
    /// </summary>
    public static async Task<T?> GetObjectFromJsonAsync<T>(
        IDatabase db,
        string key)
    {
        var val = await db.StringGetAsync(key);
        if (val.IsNullOrEmpty) return default;

        ReadOnlySpan<byte> span = ((ReadOnlyMemory<byte>)val).Span;
        return JsonSerializer.Deserialize<T>(span, Options);
    }

}
