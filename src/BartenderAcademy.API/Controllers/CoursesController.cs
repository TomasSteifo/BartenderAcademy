using System.Collections.Generic;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.CourseCommands;
using BartenderAcademy.Application.Common;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Queries.CourseQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BartenderAcademy.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// POST /api/v1/courses
        /// Creates a new Course.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<OperationResult<CourseDto>>> Create([FromBody] CreateCourseCommand command)
        {
            if (command == null)
                return BadRequest(OperationResult<CourseDto>.Fail("Request body is null."));

            var created = await _mediator.Send(command);
            var result = OperationResult<CourseDto>.Ok(created, "Course created successfully.");
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        /// <summary>
        /// GET /api/v1/courses
        /// Returns all courses.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<OperationResult<IEnumerable<CourseDto>>>> GetAll()
        {
            var courses = await _mediator.Send(new GetAllCoursesQuery());
            return Ok(OperationResult<IEnumerable<CourseDto>>.Ok(courses));
        }

        /// <summary>
        /// GET /api/v1/courses/{id}
        /// Returns a single course by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult<CourseDto>>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(OperationResult<CourseDto>.Fail("ID must be greater than zero."));

            var course = await _mediator.Send(new GetCourseByIdQuery(id));
            if (course == null)
                return NotFound(OperationResult<CourseDto>.Fail($"Course with ID {id} not found."));

            return Ok(OperationResult<CourseDto>.Ok(course));
        }

        /// <summary>
        /// PUT /api/v1/courses/{id}
        /// Updates an existing course.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<CourseDto>>> Update(int id, [FromBody] UpdateCourseCommand command)
        {
            if (command == null || id != command.Id)
                return BadRequest(OperationResult<CourseDto>.Fail("ID mismatch or request body is null."));

            var updated = await _mediator.Send(command);
            if (updated == null)
                return NotFound(OperationResult<CourseDto>.Fail($"Course with ID {id} not found."));

            return Ok(OperationResult<CourseDto>.Ok(updated, "Course updated successfully."));
        }

        /// <summary>
        /// DELETE /api/v1/courses/{id}
        /// Deletes a course.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(OperationResult<bool>.Fail("ID must be greater than zero."));

            var success = await _mediator.Send(new DeleteCourseCommand { Id = id });
            if (!success)
                return NotFound(OperationResult<bool>.Fail($"Course with ID {id} not found."));

            return Ok(OperationResult<bool>.Ok(true, "Course deleted successfully."));
        }
    }
}
