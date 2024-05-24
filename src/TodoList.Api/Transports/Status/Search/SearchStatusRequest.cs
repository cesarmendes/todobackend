using TodoList.UserCases.Status.Search;
using TodoList.UserCases.Tasks.Search;

namespace TodoList.Api.Transports.Status.Search
{
    public record SearchStatusRequest
    {
        public string? Name { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public SearchStatusQuery AsQuery()
        {
            return new SearchStatusQuery { Name = Name, Page = Page, Size = Size };
        }
    }
}
