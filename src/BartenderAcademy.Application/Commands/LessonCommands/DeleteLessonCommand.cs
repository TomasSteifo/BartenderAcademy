using MediatR;

namespace BartenderAcademy.Application.Commands.LessonCommands
{
    /// <summary>
    /// Command to delete a Lesson by ID.
    /// </summary>
    public class DeleteLessonCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
