using System.Collections.Generic;
using System.Threading.Tasks;
using BartenderAcademy.Application.Commands;
using BartenderAcademy.Application.Common;
using BartenderAcademy.Application.DTOs;
using BartenderAcademy.Application.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BartenderAcademy.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// POST /api/v1/categories
        /// Creates a new Category.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<OperationResult<CategoryDto>>> Create([FromBody] CreateCategoryCommand command)
        {
            if (command == null)
                return BadRequest(OperationResult<CategoryDto>.Fail("Request body is null."));

            var createdCategory = await _mediator.Send(command);

            // Wrap in OperationResult
            var result = OperationResult<CategoryDto>.Ok(createdCategory, "Category created successfully.");
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, result);
        }

        /// <summary>
        /// GET /api/v1/categories
        /// Returns all categories.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<OperationResult<IEnumerable<CategoryDto>>>> GetAll()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            var result = OperationResult<IEnumerable<CategoryDto>>.Ok(categories);
            return Ok(result);
        }

        /// <summary>
        /// GET /api/v1/categories/{id}
        /// Returns a single category by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<OperationResult<CategoryDto>>> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(OperationResult<CategoryDto>.Fail("ID must be greater than zero."));

            var category = await _mediator.Send(new GetCategoryByIdQuery(id));
            if (category == null)
                return NotFound(OperationResult<CategoryDto>.Fail($"Category with ID {id} not found."));

            var result = OperationResult<CategoryDto>.Ok(category);
            return Ok(result);
        }
    }
}
