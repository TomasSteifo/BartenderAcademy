using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BartenderAcademy.Application.Interfaces.Repositories
{
    /// <summary>
    /// Generic repository interface for basic CRUD operations.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> ListAllAsync(CancellationToken cancellationToken = default);
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
