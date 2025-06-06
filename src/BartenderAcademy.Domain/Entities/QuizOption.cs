namespace BartenderAcademy.Domain.Entities
{
    public class QuizOption
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key to QuizQuestion
        public int QuizQuestionId { get; set; }
        public QuizQuestion QuizQuestion { get; set; } = null!;

        // The text of this answer option (e.g., "Gin")
        public string OptionText { get; set; } = string.Empty;

        // True if this is the correct option
        public bool IsCorrect { get; set; }
    }
}
