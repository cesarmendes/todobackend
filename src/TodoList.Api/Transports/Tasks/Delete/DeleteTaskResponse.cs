using Task = TodoList.Core.Tasks.Task;

namespace TodoList.Api.Transports.Tasks.Delete
{
    public class DeleteTaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public static DeleteTaskResponse From(Task task)
        {
            ArgumentNullException.ThrowIfNull(task);

            return new DeleteTaskResponse()
            {
                Id = task.Id,
                Title = task.Title,
            };
        }
    }
}
