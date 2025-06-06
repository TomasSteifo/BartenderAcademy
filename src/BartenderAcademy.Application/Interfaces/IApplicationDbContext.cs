using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BartenderAcademy.Application.Interfaces
{
    /// <summary>
    /// Abstraction for the EF Core DbContext. Implemented in Infrastructure.
    /// </summary>
    public interface IApplicationDbContext
    {
        // DbSet for Category entity
        DbSet<Category> Categories { get; }

        // (Later, add DbSet<Course>, DbSet<Lesson>, etc.)

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
