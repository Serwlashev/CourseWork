using FluentValidation;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommandRequest>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("Category Id cannot be null")
                .GreaterThan(0)
                .WithMessage("Category Id should be greater then zero");

            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Category name cannot be null")
                .MaximumLength(100)
                .MinimumLength(2)
                .WithMessage("Category name should be 2 - 100 symbols");
        }
    }
}
