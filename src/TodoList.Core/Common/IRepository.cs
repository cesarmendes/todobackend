using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.Common
{
    public interface IRepository<TKey, TEntity>
        where TEntity : class
        where TKey : struct
    {
        ValueTask<TEntity?> GetAsync(TKey key, CancellationToken token = default);
        Task<int> InsertAsync(TEntity entity, CancellationToken token = default);
        Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken token = default);
        Task<int> UpdateAsync(TEntity entity, CancellationToken token = default);
        Task<int> UpdateAsync(IEnumerable<TEntity> entity, CancellationToken token = default);
        Task<int> DeleteAsync(TEntity entity, CancellationToken token = default);
        Task<int> DeleteAsync(IEnumerable<TEntity> entity, CancellationToken token = default);
    }
}
