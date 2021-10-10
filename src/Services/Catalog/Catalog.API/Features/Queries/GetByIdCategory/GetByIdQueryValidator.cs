using FluentValidation;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdCategory
{
    public class GetByIdQueryValidator : AbstractValidator<GetByIdCategoryQueryRequest>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(c => c.Id)
                .NotNull()
                .WithMessage("Category Id cannot be null")
                .GreaterThan(0)
                .WithMessage("Category Id should be greater then zero");
        }
    }
}
