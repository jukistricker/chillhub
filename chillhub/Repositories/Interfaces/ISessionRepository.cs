using chillhub.Models.Dtos.Responses;

namespace chillhub.Repositories.Interfaces;

public interface ISessionRepository
{
    Task StoreAsync(string jti, UserSession session, TimeSpan ttl);
    Task DeleteAsync(string jti);
    Task<UserSession?> GetAsync(string jti);
}