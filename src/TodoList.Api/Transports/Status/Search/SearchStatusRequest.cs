using TodoList.UserCases.Status.Search;
using TodoList.UserCases.Tasks.Search;

namespace TodoList.Api.Transports.Status.Search
{
    public record SearchStatusRequest
    {
        public string? Name { get; set; }

        public SearchStatusQuery AsQuery()
        {
            return new SearchStatusQuery { Name = Name };
        }
    }
}
