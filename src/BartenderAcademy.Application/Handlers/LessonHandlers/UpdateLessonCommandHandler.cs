using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.LessonCommands;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Domain.Entities;
using BartenderAcademy.Domain.Enums;  // <-- for ContentType enum
using MediatR;

namespace BartenderAcademy.Application.Handlers.LessonHandlers
{
    public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, LessonDto?>
    {
        private readonly IRepository<Lesson> _repository;

        public UpdateLessonCommandHandler(IRepository<Lesson> repository)
        {
            _repository = repository;
        }

        public async Task<LessonDto?> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return null;

            entity.CourseId = request.CourseId;
            entity.Title = request.Title;
            // Cast from int to the enum:
            entity.ContentType = (ContentType)request.ContentType;
            entity.VideoUrl = request.VideoUrl;
            entity.OrderIndex = request.OrderIndex;
            entity.Duration = request.Duration;

            _repository.Update(entity);
            await _repository.SaveChangesAsync(cancellationToken);

            return new LessonDto
            {
                Id = entity.Id,
                CourseId = entity.CourseId,
                Title = entity.Title,
                // Cast from enum back to int:
                ContentType = (int)entity.ContentType,
                VideoUrl = entity.VideoUrl,
                OrderIndex = entity.OrderIndex,
                Duration = entity.Duration
            };
        }
    }
}
