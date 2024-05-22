using FluentResults;
using MediatR;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Create
{
    public record CreateTaskCommand : IRequest<Result<Task>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}
