using System;

namespace BartenderAcademy.Domain.Entities
{
    public class Enrollment
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to User (will connect to ApplicationUser in Infrastructure)
        public string UserId { get; set; } = string.Empty;

        // Foreign key to Course
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        // When the user enrolled in the course
        public DateTime EnrolledDate { get; set; } = DateTime.UtcNow;

        // Percentage (0 to 100) of how much of the course is completed
        public decimal ProgressPercentage { get; set; } = 0m;

        // True if the user has passed all quizzes in the course
        public bool IsCompleted { get; set; } = false;
    }
}
