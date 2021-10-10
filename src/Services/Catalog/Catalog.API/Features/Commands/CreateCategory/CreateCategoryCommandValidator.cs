using FluentValidation;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("Category name cannot be null")
                .MaximumLength(100)
                .MinimumLength(2)
                .WithMessage("Category name should be 2 - 100 symbols");
        }
    }
}
