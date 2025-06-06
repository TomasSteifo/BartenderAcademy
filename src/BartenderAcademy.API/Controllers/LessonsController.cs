using System.Collections.Generic;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.LessonCommands;
using BartenderAcademy.Application.Common;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Queries.LessonQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BartenderAcademy.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LessonsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// POST /api/v1/lessons
        /// Creates a new Lesson.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<OperationResult<LessonDto>>> Create([FromBody] CreateLessonCommand command)
        {
            if (command == null)
                return BadRequest(OperationResult<LessonDto>.Fail("Request body is null."));

            var created = await _mediator.Send(command);
            var result = OperationResult<LessonDto>.Ok(created, "Lesson created successfully.");
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, result);
        }

        /// <summary>
        /// GET /api/v1/lessons/course/{courseId}
        /// Returns all lessons for a given course.
        /// </summary>
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<OperationResult<IEnumerable<LessonDto>>>> GetByCourse(int courseId)
        {
            if (courseId <= 0)
                return BadRequest(OperationResult<IEnumerable<LessonDto>>.Fail("CourseId must be greater than zero."));

            var lessons = await _mediator.Send(new GetLessonsByCourseQuery(courseId));
            return Ok(OperationResult<IEnumerable<LessonDto>>.Ok(lessons));
        }

        /// <summary>
        /// GET /api/v1/lessons/{id}
        /// Returns a single lesson by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult<LessonDto>>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(OperationResult<LessonDto>.Fail("ID must be greater than zero."));

            var lesson = await _mediator.Send(new GetLessonByIdQuery(id));
            if (lesson == null)
                return NotFound(OperationResult<LessonDto>.Fail($"Lesson with ID {id} not found."));

            return Ok(OperationResult<LessonDto>.Ok(lesson));
        }

        /// <summary>
        /// PUT /api/v1/lessons/{id}
        /// Updates an existing lesson.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<OperationResult<LessonDto>>> Update(int id, [FromBody] UpdateLessonCommand command)
        {
            if (command == null || id != command.Id)
                return BadRequest(OperationResult<LessonDto>.Fail("ID mismatch or request body is null."));

            var updated = await _mediator.Send(command);
            if (updated == null)
                return NotFound(OperationResult<LessonDto>.Fail($"Lesson with ID {id} not found."));

            return Ok(OperationResult<LessonDto>.Ok(updated, "Lesson updated successfully."));
        }

        /// <summary>
        /// DELETE /api/v1/lessons/{id}
        /// Deletes a lesson.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult<bool>>> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(OperationResult<bool>.Fail("ID must be greater than zero."));

            var success = await _mediator.Send(new DeleteLessonCommand { Id = id });
            if (!success)
                return NotFound(OperationResult<bool>.Fail($"Lesson with ID {id} not found."));

            return Ok(OperationResult<bool>.Ok(true, "Lesson deleted successfully."));
        }
    }
}
