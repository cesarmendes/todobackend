using MediatR;
using TodoList.Core.Common;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.UserCases.Tasks.Search
{
    public record SearchTasksQuery : IRequest<IPaginatedList<Task>>
    {
        public string? Title { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
