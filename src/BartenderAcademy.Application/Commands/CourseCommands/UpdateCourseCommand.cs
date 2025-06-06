using BartenderAcademy.Application.DTOs;
using MediatR;

namespace BartenderAcademy.Application.Commands.CourseCommands
{
    /// <summary>
    /// Command to update an existing Course.
    /// </summary>
    public class UpdateCourseCommand : IRequest<CourseDto?>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }
        public bool IsPublished { get; set; }
    }
}
