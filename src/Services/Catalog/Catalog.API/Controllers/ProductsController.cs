using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateProduct;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteProduct;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateProduct;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllProducts;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdProduct;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request)
            => await _mediator.Send(request);

        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllProductsQueryResponse>> GetAllProducts()
            => await _mediator.Send(new GetAllProductsQueryRequest());

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdProductQueryResponse> GetByIdProduct([FromHeader] GetByIdProductQueryRequest request)
             => await _mediator.Send(request);

        [HttpGet("find/{searchText}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<FindProductsQueryResponse>> FindProducts([FromHeader] FindProductsQueryRequest request)
             => await _mediator.Send(request);

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromBody] UpdateProductCommandRequest request)
             => await _mediator.Send(request);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct([FromHeader] DeleteProductCommandRequest request)
             => await _mediator.Send(request);
    }
}
