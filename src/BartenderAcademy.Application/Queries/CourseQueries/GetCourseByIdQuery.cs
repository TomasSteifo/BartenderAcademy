using BartenderAcademy.Application.DTOs;
using MediatR;

namespace BartenderAcademy.Application.Queries.CourseQueries
{
    /// <summary>
    /// Query to fetch a single Course by its ID.
    /// </summary>
    public class GetCourseByIdQuery : IRequest<CourseDto?>
    {
        public int Id { get; set; }

        public GetCourseByIdQuery(int id) => Id = id;
    }
}
