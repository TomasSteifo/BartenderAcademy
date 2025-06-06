using MediatR;

namespace BartenderAcademy.Application.Commands.CourseCommands
{
    /// <summary>
    /// Command to delete a Course by ID.
    /// </summary>
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
