using FluentValidation;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdProduct
{
    public class GetByIdProductValidator : AbstractValidator<GetByIdProductQueryRequest>
    {
        public GetByIdProductValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .WithMessage("Product Id cannot be null")
                .GreaterThan(0)
                .WithMessage("Product Id should be greater then zero");
        }
    }
}
