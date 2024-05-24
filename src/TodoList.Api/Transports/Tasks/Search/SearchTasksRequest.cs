using TodoList.UserCases.Tasks.Search;


namespace TodoList.Api.Transports.Tasks.Search
{
    public record SearchTasksRequest
    {
        public string? Title { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public SearchTasksQuery AsQuery() 
        {
            return new SearchTasksQuery { Title = Title, Page = Page, Size = Size };
        }
    }
}
