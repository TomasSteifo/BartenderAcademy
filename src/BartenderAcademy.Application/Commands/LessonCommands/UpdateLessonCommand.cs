using MediatR;
using BartenderAcademy.Application.DTOs;

namespace BartenderAcademy.Application.Commands.LessonCommands
{
    /// <summary>
    /// Command to update an existing Lesson.
    /// </summary>
    public class UpdateLessonCommand : IRequest<LessonDto?>
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ContentType { get; set; }
        public string? VideoUrl { get; set; }
        public int OrderIndex { get; set; }
        public int? Duration { get; set; }
    }
}
