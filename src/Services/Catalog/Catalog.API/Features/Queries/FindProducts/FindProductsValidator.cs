using FluentValidation;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts
{
    public class FindProductsValidator : AbstractValidator<FindProductsQueryRequest>
    {
        public FindProductsValidator()
        {
            RuleFor(p => p.SearchText)
                .MaximumLength(100)
                .WithMessage("Seatch text should be less then 100 characters");
        }
    }
}
