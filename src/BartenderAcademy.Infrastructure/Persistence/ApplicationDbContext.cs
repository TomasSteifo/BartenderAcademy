using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Interfaces;
using BartenderAcademy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BartenderAcademy.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Implement the Categories DbSet from IApplicationDbContext
        public DbSet<Category> Categories { get; set; } = null!;

        // TODO: Later, add DbSet<Course>, DbSet<Lesson>, DbSet<Enrollment>, etc.

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // If you need any Fluent API configurations, do them here.
            // For now, EF Core will infer PKs and FKs from your domain entities.

            // For Enrollment.ProgressPercentage, e.g. allow up to 5 digits total, 2 after the decimal:
            modelBuilder
                .Entity<Enrollment>()
                .Property(e => e.ProgressPercentage)
                .HasPrecision(5, 2);

            // For Progress.QuizScore, e.g. allow up to 5 digits total, 2 after the decimal:
            modelBuilder
                .Entity<Progress>()
                .Property(p => p.QuizScore)
                .HasPrecision(5, 2);
        }
    }
}
