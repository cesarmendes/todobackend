using MediatR;

namespace TodoList.UserCases.Status.Search
{
    public record SearchStatusQuery : IRequest<List<Core.Status.Aggregates.Status>>
    {
        public string? Name { get; set; }   
    }
}
