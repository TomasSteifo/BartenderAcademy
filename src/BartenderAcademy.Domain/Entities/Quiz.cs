using System.Collections.Generic;

namespace BartenderAcademy.Domain.Entities
{
    public class Quiz
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to Lesson (one-to-one relationship)
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; } = null!;

        // Percentage required to pass (default is 80)
        public int PassingScore { get; set; } = 80;

        // Navigation: A quiz contains multiple questions
        public ICollection<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();
    }
}
