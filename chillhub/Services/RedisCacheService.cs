using chillhub.Utils;
using StackExchange.Redis;

namespace chillhub.Services;

public class RedisCacheService : ICacheService
{
    private readonly IDatabase _redisDb;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redisDb = redis.GetDatabase();
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? ttl = null)
    {
        return RedisUtil.SetObjectAsJsonAsync(_redisDb, key, value, ttl ?? TimeSpan.FromHours(1));
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        return await RedisUtil.GetObjectFromJsonAsync<T>(_redisDb, key);
    }

    public Task RemoveAsync(string key)
    {
        return _redisDb.KeyDeleteAsync(key);
    }
}