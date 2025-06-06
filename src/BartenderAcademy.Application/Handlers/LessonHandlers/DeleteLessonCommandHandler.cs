using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.LessonCommands;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Domain.Entities;
using MediatR;

namespace BartenderAcademy.Application.Handlers.LessonHandlers
{
    public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, bool>
    {
        private readonly IRepository<Lesson> _repository;

        public DeleteLessonCommandHandler(IRepository<Lesson> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
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
