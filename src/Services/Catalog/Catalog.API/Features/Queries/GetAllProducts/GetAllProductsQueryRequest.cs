using MediatR;
using System.Collections.Generic;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : IRequest<List<GetAllProductsQueryResponse>>
    {
    }
}
