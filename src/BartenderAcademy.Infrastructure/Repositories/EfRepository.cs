using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Interfaces;
using BartenderAcademy.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BartenderAcademy.Infrastructure.Repositories
{
    /// <summary>
    /// EF Core implementation of IRepository&lt;T&gt;.
    /// </summary>
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly IApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(IApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // requires IApplicationDbContext to expose Set<T>()
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
