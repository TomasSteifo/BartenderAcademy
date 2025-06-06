namespace BartenderAcademy.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object for Course.
    /// </summary>
    public class CourseDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string CreatedByInstructorId { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
