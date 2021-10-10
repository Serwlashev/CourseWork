using AutoMapper;
using MediatR;
using Services.Catalog.Core.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts
{
    public class FindProductsQueryHandler
        : IRequestHandler<FindProductsQueryRequest, List<FindProductsQueryResponse>>
    {
        private readonly IServiceManager _serviceManager;
        private IMapper _mapper;

        public FindProductsQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<List<FindProductsQueryResponse>> Handle(FindProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _serviceManager.ProductService.FindAsync(request.SearchText);

            return _mapper.Map<List<FindProductsQueryResponse>>(products);
        }
    }
}
