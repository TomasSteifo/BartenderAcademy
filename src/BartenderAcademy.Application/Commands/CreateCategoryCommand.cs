using MediatR;
using BartenderAcademy.Application.DTOs;

namespace BartenderAcademy.Application.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
