namespace chillhub.Repositories.Interfaces;

using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Search;
using EFCore.BulkExtensions;
using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    IQueryable<T> GetQueryable();
    Task<T?> GetByIdAsync<TKey>(TKey id);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    Task<CursorResponse<TModel>> GetByCursorAsync<TModel, TKey>(
        IQueryable<TModel> query,
        CursorRequest request,
        Expression<Func<TModel, TKey>> idSelector) where TKey : IComparable;

    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    Task<bool> SaveChangesAsync();
    //Bulk Extension
    Task BulkInsertOrUpdateAsync(List<T> entities, BulkConfig bulkConfig);
    Task BulkUpdateAsync(List<T> entities, BulkConfig? bulkConfig = null);
    Task BulkDeleteAsync(List<T> entities, BulkConfig? bulkConfig = null);
}