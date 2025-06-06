using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Application.Queries.LessonQueries;
using BartenderAcademy.Domain.Entities;
using BartenderAcademy.Domain.Enums;  // <-- for ContentType enum
using MediatR;

namespace BartenderAcademy.Application.Handlers.LessonHandlers
{
    public class GetLessonByIdQueryHandler : IRequestHandler<GetLessonByIdQuery, LessonDto?>
    {
        private readonly IRepository<Lesson> _repository;

        public GetLessonByIdQueryHandler(IRepository<Lesson> repository)
        {
            _repository = repository;
        }

        public async Task<LessonDto?> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return null;

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
