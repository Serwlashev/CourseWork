using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse>
    {
        public long Id { get; set; }
    }
}
