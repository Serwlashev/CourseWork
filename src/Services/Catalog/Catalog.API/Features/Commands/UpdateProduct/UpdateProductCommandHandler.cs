using MediatR;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public UpdateProductCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            ProductDTO product = new ProductDTO
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price,
                Number = request.Number,
                Category = new CategoryDTO { Id = request.CategoryId }
            };

            bool result = await _serviceManager.ProductService.UpdateAsync(product);

            return new UpdateProductCommandResponse
            {
                Succeed = result,
                Message = result ? $"Product { product.Name } was successfully updated" : $"Cannot update product { product.Name }!"
            };
        }
    }
}
