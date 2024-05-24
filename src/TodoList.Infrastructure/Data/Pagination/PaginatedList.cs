using TodoList.Core.Common;

namespace TodoList.Infrastructure.Data.Pagination
{
    public class PaginatedList<T> : List<T>, IPaginatedList<T>
    {
        public PaginatedList(List<T> items, int totalPages, int totalItems, int pageNumber, int pageSize)
        {
            TotalPages = totalPages;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;

            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;
            IsFirstPage = PageNumber == 1;
            IsLastPage = PageNumber == TotalPages;

            this.AddRange(items);
        }

        public int TotalPages { get; private set; }

        public int TotalItems { get; private set; }

        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public bool HasPreviousPage { get; private set; }

        public bool HasNextPage { get; private set; }

        public bool IsFirstPage { get; private set; }

        public bool IsLastPage { get; private set; }
    }
}
