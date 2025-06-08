using System.Collections.Generic;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands.LessonCommands;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Queries.LessonQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<LessonDto>> Create([FromBody] CreateLessonCommand command)
        {
            if (command == null)
                return BadRequest();

            var created = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        /// <summary>
        /// GET /api/v1/lessons/course/{courseId}
        /// Returns all lessons for a given course.
        /// </summary>
        [HttpGet("course/{courseId}")]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetByCourse(int courseId)
        {
            if (courseId <= 0)
                return BadRequest();

            var lessons = await _mediator.Send(new GetLessonsByCourseQuery(courseId));
            return Ok(lessons);
        }

        /// <summary>
        /// GET /api/v1/lessons/{id}
        /// Returns a single lesson by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDto>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var lesson = await _mediator.Send(new GetLessonByIdQuery(id));
            if (lesson == null)
                return NotFound();

            return Ok(lesson);
        }

        /// <summary>
        /// PUT /api/v1/lessons/{id}
        /// Updates an existing lesson.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<LessonDto>> Update(int id, [FromBody] UpdateLessonCommand command)
        {
            if (command == null || id != command.Id)
                return BadRequest();

            var updated = await _mediator.Send(command);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        /// <summary>
        /// DELETE /api/v1/lessons/{id}
        /// Deletes a lesson.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            var success = await _mediator.Send(new DeleteLessonCommand { Id = id });
            if (!success)
                return NotFound();

            return Ok(true);
        }
    }
}
