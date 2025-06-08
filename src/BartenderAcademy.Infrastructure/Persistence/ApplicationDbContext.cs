using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Interfaces;
using BartenderAcademy.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BartenderAcademy.Infrastructure.Persistence
{
    public class ApplicationDbContext
        : IdentityDbContext<IdentityUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // --- your DbSets for domain entities ---
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Lesson> Lessons { get; set; } = null!;
        public DbSet<Enrollment> Enrollments { get; set; } = null!;
        public DbSet<Progress> Progress { get; set; } = null!;
        public DbSet<Quiz> Quiz { get; set; } = null!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public DbSet<QuizOption> QuizOptions { get; set; } = null!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(cancellationToken);

        // Remove the public override of Set<T>() entirely.
        // Instead explicitly implement the interface:
        DbSet<T> IApplicationDbContext.Set<T>() where T : class
            => base.Set<T>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Identity tables

            // singular table mappings & precision settings…
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Lesson>().ToTable("Lesson");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<QuizQuestion>().ToTable("QuizQuestion");
            modelBuilder.Entity<QuizOption>().ToTable("QuizOption");

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.ProgressPercentage)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Progress>()
                .Property(p => p.QuizScore)
                .HasPrecision(5, 2);
        }
    }
}
