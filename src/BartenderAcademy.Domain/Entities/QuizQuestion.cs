using System.Collections.Generic;
using BartenderAcademy.Domain.Enums;
using Microsoft.VisualBasic.FileIO;

namespace BartenderAcademy.Domain.Entities
{
    public class QuizQuestion
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to Quiz
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;

        // The question text (e.g., "Which ingredient is in a Martini?")
        public string QuestionText { get; set; } = string.Empty;

        // The type of question (e.g., MultipleChoice)
        public QuestionType Type { get; set; } = QuestionType.MultipleChoice;

        // Navigation: A question has multiple options
        public ICollection<QuizOption> Options { get; set; } = new List<QuizOption>();
    }
}
