using Microsoft.EntityFrameworkCore;
using TodoList.Core.Common;
using TodoList.Core.Status.Aggregates;
using TodoList.Core.Status.Repositories;
using TodoList.Infrastructure.Data.Pagination;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class StatusRepository : Repository<int, Status>, IStatusRepository
    {
        public StatusRepository(TodoListContext context)
            : base(context)
        {
        }

        public Task<IPaginatedList<Status>> SearchAsync(string? name, int page, int size, CancellationToken token = default)
        {
            var query = from status in _context.Set<Status>()
                        where string.IsNullOrEmpty(name) || status.Name.Contains(name)
                        orderby status.Id descending
                        select status;

            return query.AsNoTracking().ToPaginatedListAsync(page, size);
        }
    }
}
