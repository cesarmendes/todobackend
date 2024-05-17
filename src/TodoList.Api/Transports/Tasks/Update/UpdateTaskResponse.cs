using Task = TodoList.Core.Tasks.Task;

namespace TodoList.Api.Transports.Tasks.Update
{
    public class UpdateTaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static UpdateTaskResponse From(Task task) 
        {
            ArgumentNullException.ThrowIfNull(task);

            return new UpdateTaskResponse() 
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
            };        
        }
    }
}
