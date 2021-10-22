using AutoMapper;
using MediatR;
using Services.Catalog.Core.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllProducts
{
    public class GetAllProducsQueryHandler
        : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
    {
        private readonly IServiceManager _serviceManager;
        private IMapper _mapper;

        public GetAllProducsQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken token)
        {
            var products = await _serviceManager.ProductService.GetAllAsync(token);

            return _mapper.Map<List<GetAllProductsQueryResponse>>(products);
        }
    }
}
