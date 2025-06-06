using System;
using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.CourseCommands;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Domain.Entities;
using MediatR;

namespace BartenderAcademy.Application.Handlers.CourseHandlers
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseDto>
    {
        private readonly IRepository<Course> _repository;

        public CreateCourseCommandHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = new Course
            {
                CategoryId = request.CategoryId,
                Title = request.Title,
                Description = request.Description,
                ThumbnailUrl = request.ThumbnailUrl,
                CreatedByInstructorId = request.CreatedByInstructorId,
                IsPublished = request.IsPublished,
                CreatedDate = DateTime.UtcNow
            };

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

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
