using BartenderAcademy.Application.DTOs;
using MediatR;

namespace BartenderAcademy.Application.Queries.CategoryQueries
{
    /// <summary>
    /// Query to fetch a single category by its ID.
    /// </summary>
    public class GetCategoryByIdQuery : IRequest<CategoryDto?>
    {
        public int Id { get; set; }

        public GetCategoryByIdQuery(int id) => Id = id;
    }
}
