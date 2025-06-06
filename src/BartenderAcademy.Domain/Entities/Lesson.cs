using System;
using System.Collections.Generic;
using BartenderAcademy.Domain.Enums;

namespace BartenderAcademy.Domain.Entities
{
    public class Lesson
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to Course
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        // Title of the lesson (e.g., "How to Shake a Martini")
        public string Title { get; set; } = string.Empty;

        // Specifies whether it’s a video or an article
        public ContentType ContentType { get; set; } = ContentType.Video;

        // If it’s a video lesson, this is the URL to the blob or embed
        public string? VideoUrl { get; set; }

        // Order index within the course (e.g., 1, 2, 3…)
        public int OrderIndex { get; set; } = 0;

        // Duration in seconds (optional; only relevant for videos)
        public int? Duration { get; set; }

        // Navigation: Each Lesson has exactly one Quiz
        public Quiz Quiz { get; set; } = null!;

        // Navigation: Track many users’ progress on this lesson
        public ICollection<Progress> Progresses { get; set; } = new List<Progress>();
    }
}
