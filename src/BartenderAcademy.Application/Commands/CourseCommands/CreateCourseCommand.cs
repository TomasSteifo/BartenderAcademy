using BartenderAcademy.Application.DTOs;
using MediatR;

namespace BartenderAcademy.Application.Commands.CourseCommands
{
    /// <summary>
    /// Command to create a new Course.
    /// </summary>
    public class CreateCourseCommand : IRequest<CourseDto>
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string CreatedByInstructorId { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
    }
}
