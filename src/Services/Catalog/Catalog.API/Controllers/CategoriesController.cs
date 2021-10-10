using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllCategories;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdCategory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CreateCategoryCommandResponse> CreateCategory([FromBody] CreateCategoryCommandRequest request)
            => await _mediator.Send(request);

        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllCategoriesQueryResponse>> GetAllCategories()
            => await _mediator.Send(new GetAllCategoriesQueryRequest());

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdCategoryQueryResponse> GetByIdCategory([FromHeader] GetByIdCategoryQueryRequest request)
            => await _mediator.Send(request);

        [HttpPut]
        public async Task<UpdateCategoryCommandResponse> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
             => await _mediator.Send(request);

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteCategoryCommandResponse> DeleteCategory([FromHeader] DeleteCategoryCommandRequest request)
             => await _mediator.Send(request);
    }
}
