namespace chillhub.Repositories.Interfaces;

using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Search;
using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetQueryable();
    Task<T?> GetByIdAsync<TKey>(TKey id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<CursorResponse<T>> GetByCursorAsync<TKey>(
            IQueryable<T> query,
            CursorRequest request,
            Expression<Func<T, TKey>> idSelector) where TKey : IComparable;
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();
}