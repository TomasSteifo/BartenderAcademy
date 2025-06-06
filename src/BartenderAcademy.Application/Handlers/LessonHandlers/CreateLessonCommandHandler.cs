using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.LessonCommands;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Domain.Entities;
using BartenderAcademy.Domain.Enums;  // <-- needed for ContentType enum
using MediatR;

namespace BartenderAcademy.Application.Handlers.LessonHandlers
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, LessonDto>
    {
        private readonly IRepository<Lesson> _repository;

        public CreateLessonCommandHandler(IRepository<Lesson> repository)
        {
            _repository = repository;
        }

        public async Task<LessonDto> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Lesson
            {
                CourseId = request.CourseId,
                Title = request.Title,
                // Cast from int to the ContentType enum:
                ContentType = (ContentType)request.ContentType,
                VideoUrl = request.VideoUrl,
                OrderIndex = request.OrderIndex,
                Duration = request.Duration
            };

            await _repository.AddAsync(entity, cancellationToken);
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
