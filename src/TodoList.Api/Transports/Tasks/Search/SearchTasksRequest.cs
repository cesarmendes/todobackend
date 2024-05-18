using TodoList.UserCases.Tasks.Search;


namespace TodoList.Api.Transports.Tasks.Search
{
    public record SearchTasksRequest
    {
        public string? Title { get; set; }

        public SearchTasksQuery AsQuery() 
        {
            return new SearchTasksQuery { Title = Title };
        }
    }
}
