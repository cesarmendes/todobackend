using TodoList.Core.Common;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Core.Tasks.Repositories
{
    public interface ITaskRepository : IRepository<int, Task>
    {
        Task<List<Task>> SearchAsync(string? title, CancellationToken token = default);
    }
}
