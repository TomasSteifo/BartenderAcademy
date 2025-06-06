using MediatR;
using BartenderAcademy.Application.DTOs;

namespace BartenderAcademy.Application.Queries.LessonQueries
{
    /// <summary>
    /// Query to fetch a single Lesson by its ID.
    /// </summary>
    public class GetLessonByIdQuery : IRequest<LessonDto?>
    {
        public int Id { get; set; }

        public GetLessonByIdQuery(int id) => Id = id;
    }
}
