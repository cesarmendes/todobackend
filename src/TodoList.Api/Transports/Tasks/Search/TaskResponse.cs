using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Api.Transports.Tasks.Search
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public DateTime CreateAt { get; set; }

        public static TaskResponse From(Task task) 
        {
            return new TaskResponse 
            { 
                Id = task.Id, 
                CreateAt = task.CreateAt, 
                Description = task.Description, 
                StatusId = task.StatusId, 
                Title = task.Title 
            };
        }

        public static List<TaskResponse> From(IEnumerable<Task> tasks) 
        {
            var result = new List<TaskResponse>();

            foreach (var task in tasks) 
            {
                result.Add(From(task));
            }

            return result;
        }
    }
}
