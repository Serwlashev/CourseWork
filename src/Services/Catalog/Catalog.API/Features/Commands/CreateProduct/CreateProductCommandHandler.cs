using MediatR;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IServiceManager _serviceManager;
        
        public CreateProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductDTO product = new ProductDTO
            {
                Name = request.Name,
                Price = request.Price,
                Number = request.Number,
                CategoryId = request.CategoryId
            };

            bool result = await _serviceManager.ProductService.CreateAsync(product);

            return new CreateProductCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product { product.Name } was successfully added" : $"Cannot add product { product.Name }!"
            };
        }
    }
}
