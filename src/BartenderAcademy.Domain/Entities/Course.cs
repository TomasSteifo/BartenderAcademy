using System;
using System.Collections.Generic;

namespace BartenderAcademy.Domain.Entities
{
    public class Course
    {
        public int Id { get; set; }

        // Foreign key to Category
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        // Title of the course (e.g., "Advanced Mixology")
        public string Title { get; set; } = string.Empty;

        // Optional description or syllabus
        public string? Description { get; set; }

        // URL to a thumbnail image (e.g., course cover art)
        public string? ThumbnailUrl { get; set; }

        // The user (instructor) who created this course. Store their user‐ID string here.
        public string CreatedByInstructorId { get; set; } = string.Empty;

        // Whether the course is published and visible to students
        public bool IsPublished { get; set; } = false;

        // When the course was created
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // Navigation: a course has many lessons
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

        // Navigation: a course has many enrollments
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
