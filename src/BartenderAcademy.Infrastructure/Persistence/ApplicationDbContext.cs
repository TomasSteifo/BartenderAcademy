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

        // 1. Implement every DbSet<T> defined in IApplicationDbContext:
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;         // Maps to "Course" table
        public DbSet<Lesson> Lessons { get; set; } = null!;         // Maps to "Lesson" table
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Progress> Progress { get; set; } = null!;
        public DbSet<Quiz> Quiz { get; set; } = null!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public DbSet<QuizOption> QuizOptions { get; set; } = null!;

        // 2. Override SaveChangesAsync
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        // 3. Override Set<T>()
        public override DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ————————————————
            // Add these explicit mappings so EF uses the singular table names:
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            // (If your other tables are named singularly, map them here as well,
            //  e.g. modelBuilder.Entity<Enrollment>().ToTable("Enrollment"); etc.)
            // ————————————————

            // Preserve your existing precision settings:
            modelBuilder
                .Entity<Enrollment>()
                .Property(e => e.ProgressPercentage)
                .HasPrecision(5, 2);

            modelBuilder
                .Entity<Progress>()
                .Property(p => p.QuizScore)
                .HasPrecision(5, 2);
        }
    }
}
