using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public long Id { get; set; }
    }
}
