using TodoList.Api.Migrations;
using TodoList.Api.Transports.Tasks.Search;
using TodoList.Core.Common;

namespace TodoList.Api.Transports.Status.Search
{
    public class SearchStatusResponse
    {
        public int TotalPages { get; set; }

        public int TotalItems { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public List<StatusResponse> Items { get; set; }

        public static SearchStatusResponse From(IPaginatedList<Core.Status.Aggregates.Status> status)
        {
            return new SearchStatusResponse
            {
                HasPreviousPage = status.HasPreviousPage,
                HasNextPage = status.HasNextPage,
                IsFirstPage = status.IsFirstPage,
                IsLastPage = status.IsLastPage,
                TotalPages = status.TotalPages,
                TotalItems = status.TotalItems,
                Items = StatusResponse.From(status),
                PageNumber = status.PageNumber,
                PageSize = status.PageSize,
            };
        }
    }
}
