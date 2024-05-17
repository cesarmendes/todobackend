using TodoList.Core.Common;

namespace TodoList.Core.Tasks
{
    public interface ITaskRepository : IRepository<int, Task>
    {
    }
}
