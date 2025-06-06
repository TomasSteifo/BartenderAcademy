using MediatR;
using BartenderAcademy.Application.DTOs;

namespace BartenderAcademy.Application.Commands.LessonCommands
{
    /// <summary>
    /// Command to create a new Lesson.
    /// </summary>
    public class CreateLessonCommand : IRequest<LessonDto>
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ContentType { get; set; }
        public string? VideoUrl { get; set; }
        public int OrderIndex { get; set; }
        public int? Duration { get; set; }
    }
}
