using AutoMapper;
using MediatR;
using Services.Catalog.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _serviceManager.ProductService.GetAsync(request.Id);

            return _mapper.Map<GetByIdProductQueryResponse>(product);
        }
    }
}
