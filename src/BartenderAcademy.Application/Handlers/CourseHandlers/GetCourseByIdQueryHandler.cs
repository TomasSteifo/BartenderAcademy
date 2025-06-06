using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Application.Queries.CourseQueries;
using BartenderAcademy.Domain.Entities;
using MediatR;

namespace BartenderAcademy.Application.Handlers.CourseHandlers
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
    {
        private readonly IRepository<Course> _repository;

        public GetCourseByIdQueryHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return null;

            return new CourseDto
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Title = entity.Title,
                Description = entity.Description,
                ThumbnailUrl = entity.ThumbnailUrl,
                CreatedByInstructorId = entity.CreatedByInstructorId,
                IsPublished = entity.IsPublished,
                CreatedDate = entity.CreatedDate
            };
        }
    }
}
