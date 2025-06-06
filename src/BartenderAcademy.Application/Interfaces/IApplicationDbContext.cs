using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BartenderAcademy.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Category> Categories { get; }
        DbSet<Course> Courses { get; }
        DbSet<Lesson> Lessons { get; }
        DbSet<Enrollment> Enrollments { get; }
        DbSet<Progress> Progress { get; }
        DbSet<Quiz> Quiz { get; }
        DbSet<QuizQuestion> QuizQuestions { get; }
        DbSet<QuizOption> QuizOptions { get; }

        /// <summary>
        /// Allows repository to access any DbSet&lt;T&gt;.
        /// </summary>
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
