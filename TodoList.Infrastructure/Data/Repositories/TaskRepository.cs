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
    }
}
