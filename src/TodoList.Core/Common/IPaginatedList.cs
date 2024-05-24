using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Common
{
    public interface IPaginatedList<T> : IList<T>
    {
        int TotalPages { get; }

        int TotalItems { get; }

        int PageNumber { get; }

        int PageSize { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }
    }
}
