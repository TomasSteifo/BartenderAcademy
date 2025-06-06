using System.Collections.Generic;
using BartenderAcademy.Application.DTOs;
using MediatR;

namespace BartenderAcademy.Application.Queries.CategoryQueries
{
    /// <summary>
    /// Query to fetch all categories.
    /// </summary>
    public class GetAllCategoriesQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }
}
