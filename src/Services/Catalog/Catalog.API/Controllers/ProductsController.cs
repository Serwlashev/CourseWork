using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateProduct;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteProduct;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateProduct;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllProducts;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdProduct;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _logger.LogTrace("\"ProductsController\" was successfully created");
        }

        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request, CancellationToken token)
        {
            _logger.LogDebug("Action \"CreateProduct\" received request");
            _logger.LogTrace($"Product name {request.Name}");

            var response = await _mediator.Send(request, token);

            if (response.Succeed)
            {
                _logger.LogDebug($"New product has been successfully created");
            }
            else
            {
                _logger.LogDebug($"Cannot create product");
            }

            return response;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllProductsQueryResponse>> GetAllProducts(CancellationToken token)
        {
            _logger.LogDebug("Action \"GetAllProducts\" received request");

            var response = await _mediator.Send(new GetAllProductsQueryRequest(), token);

            if (response is not null && response.Count > 0)
            {
                _logger.LogDebug($"Action \"GetAllProducts\" returned { response.Count } products");
            }
            else
            {
                _logger.LogDebug($"Products not found");
            }

            return response;
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdProductQueryResponse> GetByIdProduct([FromHeader] GetByIdProductQueryRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"GetByIdProduct\" received request, id = { request.Id }");

            var response = await _mediator.Send(request, token);

            if (response is not null)
            {
                _logger.LogDebug($"Action \"GetByIdProduct\" found { response.Name } product with id { response.Id }");
            }
            else
            {
                _logger.LogDebug($"Product with id = { request.Id } not found");
            }

            return response;
        }

        [HttpGet("find/{searchText}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<FindProductsQueryResponse>> FindProducts([FromHeader] FindProductsQueryRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"FindProducts\" received request, request text - \"{ request.SearchText }\"");


            var response = await _mediator.Send(request, token);

            if (response is not null && response.Count > 0)
            {
                _logger.LogDebug($"Action \"FindProducts\" found { response.Count } products");
            }
            else
            {
                _logger.LogDebug($"Products not found");
            }

            return response;
        }

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromBody] UpdateProductCommandRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"UpdateProduct\" received request, id = { request.Id }");

            var response = await _mediator.Send(request, token);

            if (response.Succeed)
            {
                _logger.LogDebug($"Product was updated successfully");
            }
            else
            {
                _logger.LogDebug($"Cannot update product");
            }

            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct([FromHeader] DeleteProductCommandRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"DeleteProduct\" received request, id = { request.Id }");

            var response = await _mediator.Send(request, token);

            if (response.Succeed)
            {
                _logger.LogDebug($"Product was deleted successfully");
            }
            else
            {
                _logger.LogDebug($"Cannot delete product");
            }

            return response;
        }
    }
}
