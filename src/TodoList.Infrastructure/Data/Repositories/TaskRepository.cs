using Microsoft.EntityFrameworkCore;
using TodoList.Core.Common;
using TodoList.Core.Tasks.Repositories;
using TodoList.Infrastructure.Data.Pagination;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class TaskRepository : Repository<int, Task>, ITaskRepository
    {
        public TaskRepository(TodoListContext context)
            : base(context)
        {
        }

        public Task<IPaginatedList<Task>> SearchAsync(string? title, int page, int size, CancellationToken token = default)
        {
            var query = from task in _context.Set<Task>()
                        where string.IsNullOrEmpty(title) || task.Title.Contains(title)
                        select task;

            return query.AsNoTracking().ToPaginatedListAsync(page, size, token);
        }
    }
}
