using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Generics
{
    public interface IRepository<T> where T : class
    {
        Task CreateAsync(T entity);
        Task<T?> ReadByIdAsync(object entityKey);
        Task<T?> ReadFirstAsync(Expression<Func<T, bool>>? expression = null);
        Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? expression = null, params string[] includes);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object entityKey);
        Task DeleteAsync(T entity);
    }
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;
        protected Repository(DbContext db)
        {
            _context = db;
            _set = db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task<T?> ReadByIdAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        public async Task<T?> ReadFirstAsync(Expression<Func<T, bool>>? expression = null)
        {
            if (expression == null)
                return await _set.FirstOrDefaultAsync();
            return await _set.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> ReadManyAsync(Expression<Func<T, bool>>? expression = null, params string[] includes)
        {
            IQueryable<T> query = _set;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(object entityKey)
        {
            var entity = await _set.FindAsync(entityKey);
            if (entity != null)
            {
                _set.Remove(entity);
            }
        }

        public async Task DeleteAsync(T entity)
        {
            _set.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
