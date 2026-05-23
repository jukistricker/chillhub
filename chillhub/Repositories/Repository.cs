using chillhub.Models.Dtos.Requests.Search;
using chillhub.Models.Dtos.Responses.Search;
using chillhub.Repositories.Interfaces;
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

    public async Task<CursorResponse<T>> GetByCursorAsync<TKey>(
        IQueryable<T> query,
        CursorRequest request,
        Expression<Func<T, TKey>> idSelector) where TKey : IComparable
    {
        var getIdFunc = idSelector.Compile();

        // 1. Xử lý điều kiện lọc ranh giới Cursor (Id < Mốc hoặc Id > Mốc)
        if (!string.IsNullOrEmpty(request.Cursor))
        {
            var targetType = typeof(TKey);

            // Ép kiểu chuỗi Cursor nhận từ Client về đúng kiểu dữ liệu của trường mốc (int, long, Guid)
            TKey parsedCursor = (TKey)(targetType == typeof(Guid)
                ? (object)Guid.Parse(request.Cursor)
                : Convert.ChangeType(request.Cursor, targetType));

            // Định nghĩa toán tử so sánh dựa theo chiều sắp xếp sắp xếp
            // Mới nhất lên đầu (IsDescending = true): Lấy các bản ghi cũ hơn mốc (Id < parsedCursor)
            // Cũ nhất lên đầu (IsDescending = false): Lấy các bản ghi mới hơn mốc (Id > parsedCursor)
            Func<Expression, Expression, BinaryExpression> comparisonOp = request.IsDescending
                ? Expression.LessThan
                : Expression.GreaterThan;

            // Xây dựng câu lệnh Expression động: x => x.Id < parsedCursor
            var binaryExpression = comparisonOp(idSelector.Body, Expression.Constant(parsedCursor));
            var lambdaCriteria = Expression.Lambda<Func<T, bool>>(binaryExpression, idSelector.Parameters);

            query = query.Where(lambdaCriteria);
        }

        // 2. Tự động áp dụng mệnh đề sắp xếp
        query = request.IsDescending
            ? query.OrderByDescending(idSelector)
            : query.OrderBy(idSelector);

        // 3. Thực thi truy vấn lấy dư 1 bản ghi (Take PageSize + 1) để kiểm tra HasNextPage
        var items = await query.Take(request.PageSize + 1).ToListAsync();
        var hasNextPage = items.Count > request.PageSize;

        if (hasNextPage)
        {
            // Bỏ bản ghi thừa đi sau khi đã xác nhận có trang kế tiếp
            items.RemoveAt(items.Count - 1);
        }

        // 4. Trả về kết quả phân trang
        return new CursorResponse<T>
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

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}