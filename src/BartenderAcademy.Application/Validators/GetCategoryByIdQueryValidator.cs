using FluentValidation;
using BartenderAcademy.Application.Queries.CategoryQueries;

namespace BartenderAcademy.Application.Validators
{
    /// <summary>
    /// Validates that the requested category ID is greater than zero.
    /// </summary>
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Category ID must be greater than zero.");
        }
    }
}
