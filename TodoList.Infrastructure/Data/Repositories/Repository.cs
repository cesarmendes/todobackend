using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Common;

namespace TodoList.Infrastructure.Data.Repositories
{
    public abstract class Repository<TKey, TEntity> : IRepository<TKey, TEntity>
        where TEntity : class
        where TKey : struct
    {
        private readonly DbContext _context;
        protected Repository(DbContext context)
        {
            _context = context;
        }

        public ValueTask<TEntity?> GetAsync(TKey key, CancellationToken token = default)
        {
            return _context.Set<TEntity>().FindAsync(key, token);
        }

        public Task<int> InsertAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Add(entity);

            return _context.SaveChangesAsync(token);
        }

        public Task<int> InsertAsync(IEnumerable<TEntity> entities, CancellationToken token = default)
        {
            _context.Set<TEntity>().AddRange(entities);

            return _context.SaveChangesAsync(token);
        }

        public Task<int> UpdateAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Update(entity);

            return _context.SaveChangesAsync(token);
        }

        public Task<int> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken token = default)
        {
            _context.Set<TEntity>().UpdateRange(entities);

            return _context.SaveChangesAsync(token);
        }

        public Task<int> DeleteAsync(TEntity entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().Remove(entity);

            return _context.SaveChangesAsync(token);
        }

        public Task<int> DeleteAsync(IEnumerable<TEntity> entity, CancellationToken token = default)
        {
            _context.Set<TEntity>().RemoveRange(entity);

            return _context.SaveChangesAsync(token);
        }
       
    }
}
