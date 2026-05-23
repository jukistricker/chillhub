using StackExchange.Redis;
using System.Text.Json;

namespace chillhub.Utils;

public static class RedisUtil
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNameCaseInsensitive = true, 
        PropertyNamingPolicy = null
    };

    public static async Task SetHashAsync(
        IDatabase db,
        string key,
        IEnumerable<KeyValuePair<string, object>> values,
        TimeSpan? expiry = null)
    {
        var entries = values.Select(kv =>
            new HashEntry(kv.Key, SerializeToRedisValue(kv.Value))
        ).ToArray();

        await db.HashSetAsync(key, entries);

        if (expiry.HasValue)
            await db.KeyExpireAsync(key, expiry.Value);
    }

    public static async Task<T?> GetFieldAsync<T>(IDatabase db, string key, string field)
    {
        var val = await db.HashGetAsync(key, field);
        if (val.IsNullOrEmpty) return default;

        return DeserializeRedisValue<T>(val);
    }

    public static async Task SetObjectToHashAsync<T>(
        IDatabase db,
        string key,
        T obj,
        TimeSpan? expiry = null) where T : class
    {
        if (obj == null) return;

        var jsonString = JsonSerializer.Serialize(obj, Options);
        var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString, Options);

        if (dict == null) return;

        var entries = dict.Select(kv =>
            new HashEntry(kv.Key, SerializeToRedisValue(kv.Value))
        ).ToArray();

        await db.HashSetAsync(key, entries);

        if (expiry.HasValue)
            await db.KeyExpireAsync(key, expiry.Value);
    }

    public static async Task<T?> GetObjectFromHashAsync<T>(IDatabase db, string key) where T : class, new()
    {
        var entries = await db.HashGetAllAsync(key);
        if (entries.Length == 0) return null;

        var dict = new Dictionary<string, string>();
        foreach (var entry in entries)
        {
            if (!entry.Name.IsNullOrEmpty && !entry.Value.IsNullOrEmpty)
            {
                dict[entry.Name.ToString()] = entry.Value.ToString();
            }
        }

        var jsonString = JsonSerializer.Serialize(dict, Options);
        return JsonSerializer.Deserialize<T>(jsonString, Options);
    }

    public static async Task SetObjectAsJsonAsync<T>(IDatabase db, string key, T obj, TimeSpan? expiry = null)
    {
        var jsonString = JsonSerializer.Serialize(obj, Options);
        await db.StringSetAsync(key, jsonString, (Expiration)expiry);
    }

    public static async Task<T?> GetObjectFromJsonAsync<T>(IDatabase db, string key)
    {
        var val = await db.StringGetAsync(key);
        if (val.IsNullOrEmpty) return default;

        return JsonSerializer.Deserialize<T>(val.ToString(), Options);
    }

    public static async Task DeleteFieldsAsync(IDatabase db, string key, params string[] fields)
    {
        if (fields.Length == 0) return;
        var redisFields = Array.ConvertAll(fields, f => (RedisValue)f);
        await db.HashDeleteAsync(key, redisFields);
    }

    public static async Task<bool> FieldExistsAsync(IDatabase db, string key, string field)
        => await db.HashExistsAsync(key, field);

    #region Private Helpers (Rút gọn)

    private static RedisValue SerializeToRedisValue(object? obj)
    {
        if (obj == null) return RedisValue.Null;

        if (obj is string || obj is ValueType && !(obj is Guid || obj is DateTime || obj is DateTimeOffset))
        {
            return obj.ToString()!;
        }

        return JsonSerializer.Serialize(obj, Options);
    }

    private static T? DeserializeRedisValue<T>(RedisValue val)
    {
        var str = val.ToString();

        if (typeof(T) == typeof(string)) return (T?)(object)str;

        try
        {
            return JsonSerializer.Deserialize<T>(str, Options);
        }
        catch (JsonException)
        {
            return (T?)Convert.ChangeType(str, typeof(T));
        }
    }

    #endregion
}