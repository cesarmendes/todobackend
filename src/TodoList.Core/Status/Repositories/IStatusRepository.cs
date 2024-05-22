using TodoList.Core.Common;

namespace TodoList.Core.Status.Repositories
{
    public interface IStatusRepository : IRepository<int, Aggregates.Status>
    {
        Task<List<Aggregates.Status>> SearchAsync(string? name, CancellationToken token = default);
    }
}
