using MediatR;
using System.Collections.Generic;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : IRequest<List<GetAllCategoriesQueryResponse>>
    {
    }
}
