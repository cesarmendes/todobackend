using TodoList.Core.Common;

namespace TodoList.Core.Tasks
{
    public interface ITaskRepository : IRepository<int, Task>
    {
        Task<List<Task>> SearchAsync(string? title, CancellationToken token = default);
    }
}
