using System.Collections.Generic;
using System.Linq;
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
    public class GetLessonsByCourseQueryHandler : IRequestHandler<GetLessonsByCourseQuery, IEnumerable<LessonDto>>
    {
        private readonly IRepository<Lesson> _repository;

        public GetLessonsByCourseQueryHandler(IRepository<Lesson> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LessonDto>> Handle(GetLessonsByCourseQuery request, CancellationToken cancellationToken)
        {
            var allLessons = await _repository.ListAllAsync(cancellationToken);
            var filtered = allLessons.Where(l => l.CourseId == request.CourseId);

            return filtered.Select(entity => new LessonDto
            {
                Id = entity.Id,
                CourseId = entity.CourseId,
                Title = entity.Title,
                // Cast from enum back to int:
                ContentType = (int)entity.ContentType,
                VideoUrl = entity.VideoUrl,
                OrderIndex = entity.OrderIndex,
                Duration = entity.Duration
            });
        }
    }
}
