using System.Collections.Generic;
using BartenderAcademy.Application.DTOs;
using MediatR;

namespace BartenderAcademy.Application.Queries.CourseQueries
{
    /// <summary>
    /// Query to fetch all Courses.
    /// </summary>
    public class GetAllCoursesQuery : IRequest<IEnumerable<CourseDto>>
    {
    }
}
