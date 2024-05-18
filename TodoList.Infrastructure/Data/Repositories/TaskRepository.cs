using Microsoft.EntityFrameworkCore;
using TodoList.Core.Tasks;
using TodoList.Infrastructure.Data.Contexts;
using Task = TodoList.Core.Tasks.Task;

namespace TodoList.Infrastructure.Data.Repositories
{
    public class TaskRepository : Repository<int, Task>, ITaskRepository
    {
        public TaskRepository(TodoListContext context)
            : base(context)
        {
        }

        public Task<List<Task>> SearchAsync(string? title, CancellationToken token = default)
        {
            var query = from task in _context.Set<Task>()
                        where string.IsNullOrEmpty(title) || task.Title.Contains(title)
                        select task;

            return query.AsNoTracking().ToListAsync();
        }
    }
}
