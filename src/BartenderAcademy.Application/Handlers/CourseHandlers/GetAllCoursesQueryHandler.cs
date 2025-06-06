using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Application.Queries.CourseQueries;
using BartenderAcademy.Domain.Entities;
using MediatR;

namespace BartenderAcademy.Application.Handlers.CourseHandlers
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly IRepository<Course> _repository;

        public GetAllCoursesQueryHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _repository.ListAllAsync(cancellationToken);
            return entities.Select(entity => new CourseDto
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Title = entity.Title,
                Description = entity.Description,
                ThumbnailUrl = entity.ThumbnailUrl,
                CreatedByInstructorId = entity.CreatedByInstructorId,
                IsPublished = entity.IsPublished,
                CreatedDate = entity.CreatedDate
            });
        }
    }
}
