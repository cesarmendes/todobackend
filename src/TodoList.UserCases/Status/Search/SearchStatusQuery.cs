using MediatR;
using TodoList.Core.Common;

namespace TodoList.UserCases.Status.Search
{
    public record SearchStatusQuery : IRequest<IPaginatedList<Core.Status.Aggregates.Status>>
    {
        public string? Name { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
