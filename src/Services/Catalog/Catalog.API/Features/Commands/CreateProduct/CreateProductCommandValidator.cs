using FluentValidation;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotNull()
                .WithMessage("Product name cannot be null")
                .MaximumLength(100)
                .MinimumLength(2)
                .WithMessage("Product name should be 2 - 100 symbols");

            RuleFor(p => p.Number)
                .NotNull()
                .WithMessage("Product number cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product number cannot be less then zero");

            RuleFor(p => p.Price)
                .NotNull()
                .WithMessage("Product price cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product price cannot be less then zero");

            RuleFor(p => p.CategoryId)
                .NotNull()
                .WithMessage("Product category cannot be null")
                .GreaterThan(0)
                .WithMessage("Product category Id should be greater then zero");
        }
    }
}
