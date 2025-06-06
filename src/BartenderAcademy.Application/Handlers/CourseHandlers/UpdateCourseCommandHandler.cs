using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.CourseCommands;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces.Repositories;
using BartenderAcademy.Domain.Entities;
using MediatR;

namespace BartenderAcademy.Application.Handlers.CourseHandlers
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseDto?>
    {
        private readonly IRepository<Course> _repository;

        public UpdateCourseCommandHandler(IRepository<Course> repository)
        {
            _repository = repository;
        }

        public async Task<CourseDto?> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (entity == null)
                return null;

            entity.CategoryId = request.CategoryId;
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.ThumbnailUrl = request.ThumbnailUrl;
            entity.IsPublished = request.IsPublished;

            _repository.Update(entity);
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
