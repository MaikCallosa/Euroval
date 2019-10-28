using Euroval.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Euroval.Entity.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        internal EurovalContext _context;
        internal DbSet<T> _dbSet;
        internal string[] _includes;
        internal IQueryable<T> _querable = null;

        public RepositoryAsync(EurovalContext context, string[] includes)
        {
            _context = context;
            _includes = includes;
            _dbSet = _context.Set<T>();

            foreach (string include in includes) 
            {
                if (!string.IsNullOrEmpty(include))
                {
                    if (_querable == null)
                        _querable = _dbSet.Include(include);
                    else
                        _querable = _querable.Include(include);
                }
            }           
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return _querable != null ?
                await _querable.ToListAsync() :
                await _dbSet.ToListAsync();
        }

        public async Task<T> GetOne(Expression<Func<T, bool>> predicate)
        {
            return _querable != null ?
                await _querable.FirstOrDefaultAsync(predicate) :
                await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return _querable != null ?
                await _querable.Where(predicate).ToListAsync() :
                await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Update(object id, T entity)
        {
            if (entity != null)
            {
                var entityResult = await _dbSet.FindAsync(id);
                Delete(entityResult);
                await _dbSet.AddAsync(entity);
            }
        }

        public async Task Delete(object id)
        {
            var entityResult = await _dbSet.FindAsync(id);
            Delete(entityResult);
        }

        public void Delete(T entity)
        {
            if (entity != null)
                _dbSet.Remove(entity);
        }
    }
}
