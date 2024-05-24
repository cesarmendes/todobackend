using Microsoft.EntityFrameworkCore;
using TodoList.Core.Common;

namespace TodoList.Infrastructure.Data.Pagination
{
    public static class PaginatedListExtension
    {
        public static async Task<IPaginatedList<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int page, int size, CancellationToken cancellationToken = default)
        {
            if (page < 1)
            {
                page = 1;
            }

            if (size < 1)
            {
                size = 10;
            }

            var count = await source.CountAsync(cancellationToken);
            var items = await source.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling(count / (double)size);

            return new PaginatedList<T>(items, totalPages, count, page, size);
        }
    }
}
