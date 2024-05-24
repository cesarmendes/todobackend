using TodoList.Core.Common;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Core.Tasks.Repositories
{
    public interface ITaskRepository : IRepository<int, Task>
    {
        Task<IPaginatedList<Task>> SearchAsync(string? title, int page, int size, CancellationToken token = default);
    }
}
