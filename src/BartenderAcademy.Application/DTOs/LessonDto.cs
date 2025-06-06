namespace BartenderAcademy.Application.DTOs
{
    /// <summary>
    /// DTO for Lesson.
    /// </summary>
    public class LessonDto
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ContentType { get; set; } // e.g., enum behind this
        public string? VideoUrl { get; set; }
        public int OrderIndex { get; set; }
        public int? Duration { get; set; }
    }
}
