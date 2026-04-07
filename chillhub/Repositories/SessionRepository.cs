using chillhub.Models.Dtos.Responses;
using chillhub.Repositories.Interfaces;
using chillhub.Utils;

namespace chillhub.Repositories;

using StackExchange.Redis;

public class SessionRepository : ISessionRepository
{
    private readonly IDatabase _redisDb;
    private const string KeyPrefix = "session:";

    public SessionRepository(IConnectionMultiplexer redis)
    {
        _redisDb = redis.GetDatabase();
    }

    public Task StoreAsync(string jti, UserSession session, TimeSpan ttl)
    {
        return RedisUtil.SetObjectAsJsonAsync(
            _redisDb,
            $"{KeyPrefix}{jti}",
            session,
            ttl
        );
    }

    public Task DeleteAsync(string token)
    {
        return _redisDb.KeyDeleteAsync($"{KeyPrefix}{token}");
    }

    public async Task<UserSession?> GetAsync(string jti)
    {
        return await RedisUtil.GetObjectFromJsonAsync<UserSession>(_redisDb,$"{KeyPrefix}{jti}");
    }
}