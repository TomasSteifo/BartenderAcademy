using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.CourseCommands;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Domain.Entities;
using MediatR;

namespace BartenderAcademy.Application.Handlers.CourseHandlers
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly IRepository<Course> _repository;

        public DeleteCourseCommandHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return false;

            _repository.Delete(entity);
            await _repository.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
