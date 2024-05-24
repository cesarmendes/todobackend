using TodoList.Core.Common;
using Task = TodoList.Core.Tasks.Aggregates.Task;

namespace TodoList.Api.Transports.Tasks.Search
{
    public class SearchTasksResponse
    {
        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public List<TaskResponse> Items { get; set; }

        public static SearchTasksResponse From(IPaginatedList<Task> tasks) 
        {
            return new SearchTasksResponse 
            {
                HasPreviousPage = tasks.HasPreviousPage,
                HasNextPage = tasks.HasNextPage,
                IsFirstPage = tasks.IsFirstPage,
                IsLastPage = tasks.IsLastPage,
                TotalPages = tasks.TotalPages,
                TotalItems = tasks.TotalItems,
                Items = TaskResponse.From(tasks),
                PageNumber = tasks.PageNumber,
                PageSize = tasks.PageSize,
            };
        }
    }
}
