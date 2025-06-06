using System.Threading;
using System.Threading.Tasks;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BartenderAcademy.Application.Queries.CategoryQueries
{
    /// <summary>
    /// Handler to fetch a single category by its ID.
    /// </summary>
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (category == null)
                return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
