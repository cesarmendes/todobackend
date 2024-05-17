using FluentResults;
using MediatR;
using Task = TodoList.Core.Tasks.Task;

namespace TodoList.UserCases.Tasks.Update
{
    public record UpdateTaskCommand : IRequest<Result<Task>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
