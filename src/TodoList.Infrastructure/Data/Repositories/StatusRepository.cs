using Microsoft.EntityFrameworkCore;
using TodoList.Core.Status.Aggregates;
using TodoList.Core.Status.Repositories;
using TodoList.Infrastructure.Data.Contexts;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class StatusRepository : Repository<int, Status>, IStatusRepository
    {
        public StatusRepository(TodoListContext context)
            : base(context)
        {
        }

        public Task<List<Status>> SearchAsync(string? name, CancellationToken token = default)
        {
            var query = from status in _context.Set<Status>()
                        where string.IsNullOrEmpty(name) || status.Name.Contains(name)
                        select status;

            return query.AsNoTracking().ToListAsync();
        }
    }
}
