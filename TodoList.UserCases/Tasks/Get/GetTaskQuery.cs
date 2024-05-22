using MediatR;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Get
{
    public record GetTaskQuery : IRequest<Task?>
    {
        public int Id { get; set; }
    }
}
