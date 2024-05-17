using TodoList.UserCases.Tasks.Get;

namespace TodoList.Api.Transports.Tasks.Get
{
    public record GetTaskRequest
    {
        public int Id { get; set; }

        public GetTaskQuery AsQuery() 
        {
            return new GetTaskQuery { Id = Id };
        }
    }
}
