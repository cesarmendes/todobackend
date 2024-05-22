using FluentResults;
using MediatR;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Delete
{
    public record DeleteTaskCommand : IRequest<Result<Task>>
    {
        public int Id { get; set; }
    }
}
