using MediatR;
using System.Collections.Generic;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts
{
    public class FindProductsQueryRequest : IRequest<List<FindProductsQueryResponse>>
    {
        public string SearchText { get; set; }

    }
}
