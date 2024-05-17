using TodoList.UserCases.Tasks.Delete;

namespace TodoList.Api.Transports.Tasks.Delete
{
    public class DeleteTaskRequest
    {
        public int Id { get; set; }

        public DeleteTaskCommand AsCommand() 
        {
            return new DeleteTaskCommand { Id = Id };   
        }
    }
}
