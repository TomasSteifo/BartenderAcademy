using System.Collections.Generic;
using MediatR;
using BartenderAcademy.Application.DTOs;

namespace BartenderAcademy.Application.Queries.LessonQueries
{
    /// <summary>
    /// Query to fetch all Lessons for a given Course.
    /// </summary>
    public class GetLessonsByCourseQuery : IRequest<IEnumerable<LessonDto>>
    {
        public int CourseId { get; set; }

        public GetLessonsByCourseQuery(int courseId) => CourseId = courseId;
    }
}
