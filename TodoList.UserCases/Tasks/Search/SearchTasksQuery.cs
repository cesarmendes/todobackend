using MediatR;
using Task = TodoList.Core.Tasks.Task;

namespace TodoList.UserCases.Tasks.Search
{
    public record SearchTasksQuery : IRequest<List<Task>>
    {
        public string? Title { get; set; }
    }
}
