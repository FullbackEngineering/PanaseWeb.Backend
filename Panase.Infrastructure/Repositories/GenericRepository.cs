using Microsoft.EntityFrameworkCore;
using Panase.Core.Entities;
using Panase.Core.Interfaces;
using Panase.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Panase.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApiContext _context;
        private readonly DbSet<T> _set;

        public GenericRepository(ApiContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _set.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _set.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _set.Remove(entity);
        }

        public void Update(T entity)
        {
            _set.Update(entity);
        }
    }
}
