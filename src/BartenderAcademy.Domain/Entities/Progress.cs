using System;

namespace BartenderAcademy.Domain.Entities
{
    public class Progress
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to User (will connect to ApplicationUser in Infrastructure)
        public string UserId { get; set; } = string.Empty;

        // Foreign key to Lesson
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;

        // True if the user has watched/completed the lesson content
        public bool IsLessonWatched { get; set; } = false;

        // The percentage score the user received on the quiz (0–100)
        public decimal? QuizScore { get; set; }

        // When the user took the quiz
        public DateTime? QuizTakenDate { get; set; }
    }
}

