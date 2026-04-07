using System.ComponentModel;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace chillhub.Utils;

public static class FilterUtil
{
    public static IQueryable<T> ApplyDeterministicSort<T>(this IQueryable<T> query, string fullSortParam)
    {
        return query.OrderBy(fullSortParam);
    }

    // Cursor: Dùng trực tiếp bool IsDescending để quyết định toán tử so sánh
    public static IQueryable<T> ApplyCursor<T, TCursor>(
        this IQueryable<T> query,
        string? cursor,
        string sortField,
        bool isDescending = true) where T : class
    {
        if (string.IsNullOrEmpty(cursor)) return query;

        try
        {
            var converter = TypeDescriptor.GetConverter(typeof(TCursor));
            var convertedCursor = (TCursor?)converter.ConvertFromInvariantString(cursor);

            if (convertedCursor != null)
            {
                var parameter = Expression.Parameter(typeof(T), "x");
                var property = Expression.Call(typeof(EF), nameof(EF.Property), new[] { typeof(TCursor) }, 
                    parameter, Expression.Constant(sortField));

                // Triết lý: Nếu giảm dần (Desc) thì lấy nhỏ hơn Cursor, nếu tăng dần (Asc) thì lấy lớn hơn
                var comparison = isDescending
                    ? Expression.LessThan(property, Expression.Constant(convertedCursor))
                    : Expression.GreaterThan(property, Expression.Constant(convertedCursor));

                return query.Where(Expression.Lambda<Func<T, bool>>(comparison, parameter));
            }
        }
        catch { return query.Take(0); }
        return query;
    }

    // 3. CHỌN TRƯỜNG (Dynamic Projection)
    public static IQueryable<TResult> ApplySelect<T, TResult>(this IQueryable<T> query, string? selectFields)
    {
        if (string.IsNullOrWhiteSpace(selectFields))
        {
            // Nếu không có select, ép kiểu về TResult (giả định T và TResult tương thích)
            return query.Cast<TResult>();
        }

        return query.Select<TResult>($"new({selectFields})");
    }
}