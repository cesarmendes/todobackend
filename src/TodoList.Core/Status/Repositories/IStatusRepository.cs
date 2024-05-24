using TodoList.Core.Common;

namespace TodoList.Core.Status.Repositories
{
    public interface IStatusRepository : IRepository<int, Aggregates.Status>
    {
        Task<IPaginatedList<Aggregates.Status>> SearchAsync(string? name, int page, int size, CancellationToken token = default);
    }
}
