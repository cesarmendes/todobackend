using Task = TodoList.Core.Tasks.Task;

namespace TodoList.Api.Transports.Tasks.Create
{
    public class CreateTaskResponse
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public static CreateTaskResponse From(Task task)
        {
            ArgumentNullException.ThrowIfNull(task, nameof(task));

            return new CreateTaskResponse { Id = task.Id, Title = task.Title, Description = task.Description };
        }
    }
}
