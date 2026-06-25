using chillhub.Entities.Media;
using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace chillhub.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IQueryable<T> GetQueryable()
    {
        return _dbSet.AsNoTracking();
    }

    public async Task<T?> GetByIdAsync<TKey>(TKey id)
    {
        return await _dbSet.FindAsync(id);
    }


    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public async Task<CursorResponse<TModel>> GetByCursorAsync<TModel, TKey>(
        IQueryable<TModel> query,
        CursorRequest request,
        Expression<Func<TModel, TKey>> idSelector
    ) where TKey : IComparable
    {
        var getIdFunc = idSelector.Compile();

        // 1. Xử lý điều kiện lọc ranh giới Cursor
        if (!string.IsNullOrEmpty(request.Cursor))
        {
            var targetType = typeof(TKey);

            TKey parsedCursor = (TKey)(targetType == typeof(Guid)
                ? (object)Guid.Parse(request.Cursor)
                : Convert.ChangeType(request.Cursor, targetType));

            Func<Expression, Expression, BinaryExpression> comparisonOp = request.IsDescending
                ? Expression.LessThan
                : Expression.GreaterThan;

            var binaryExpression = comparisonOp(idSelector.Body, Expression.Constant(parsedCursor));
            var lambdaCriteria = Expression.Lambda<Func<TModel, bool>>(binaryExpression, idSelector.Parameters);

            query = query.Where(lambdaCriteria);
        }

        // 2. Tự động áp dụng mệnh đề sắp xếp
        query = request.IsDescending
            ? query.OrderByDescending(idSelector)
            : query.OrderBy(idSelector);

        // 3. Thực thi truy vấn lấy dư 1 bản ghi
        var items = await query.Take(request.PageSize + 1).ToListAsync();
        var hasNextPage = items.Count > request.PageSize;

        if (hasNextPage)
        {
            items.RemoveAt(items.Count - 1);
        }

        // 4. Trả về kết quả phân trang
        return new CursorResponse<TModel>
        {
            Items = items,
            NextCursor = hasNextPage && items.Count > 0 ? getIdFunc(items.Last()).ToString() : null,
            HasNextPage = hasNextPage
        };
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task BulkInsertOrUpdateAsync(List<T> entities, BulkConfig bulkConfig)
    {
        if (entities == null || !entities.Any()) return;

        await _context.BulkInsertOrUpdateAsync(entities, bulkConfig);
    }

    public async Task BulkUpdateAsync(List<T> entities, BulkConfig? bulkConfig = null)
    {
        if (entities == null || !entities.Any()) return;
        await _context.BulkUpdateAsync(entities, bulkConfig);
    }

    public async Task BulkDeleteAsync(List<T> entities, BulkConfig? bulkConfig = null)
    {
        if (entities == null || !entities.Any()) return;
        await _context.BulkDeleteAsync(entities, bulkConfig);
    }
}