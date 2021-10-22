using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllCategories;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdCategory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
            _logger.LogTrace("\"CategoriesController\" was successfully created");
        }

        [HttpPost]
        public async Task<CreateCategoryCommandResponse> CreateCategory([FromBody] CreateCategoryCommandRequest request, CancellationToken token)
        {
            _logger.LogDebug("Action \"CreateCategory\" received request");
            _logger.LogTrace($"Category name {request.Name}");

            var response = await _mediator.Send(request, token);

            if(response.Succeed)
            {
                _logger.LogDebug($"New category has been successfully created");
            }
            else
            {
                _logger.LogDebug($"Cannot create category");
            }

            return response;
        }

        [HttpGet]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<List<GetAllCategoriesQueryResponse>> GetAllCategories(CancellationToken token)
        {
            _logger.LogDebug("Action \"GetAllCategories\" received request");

            var response = await _mediator.Send(new GetAllCategoriesQueryRequest(), token);

            if (response is not null && response.Count > 0)
            {
                _logger.LogDebug($"Action \"GetAllCategories\" returned { response.Count } categories");
            }
            else
            {
                _logger.LogDebug($"Categories not found");
            }

            return response;
        }

        [HttpGet("{id}")]
        [ResponseCache(CacheProfileName = "Caching")]
        public async Task<GetByIdCategoryQueryResponse> GetByIdCategory([FromHeader] GetByIdCategoryQueryRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"GetByIdCategory\" received request, id = { request.Id }");

            var response = await _mediator.Send(request, token);

            if (response is not null)
            {
                _logger.LogDebug($"Action \"GetByIdCategory\" found { response.Name } category with id { response.Id }");
            }
            else
            {
                _logger.LogDebug($"Category with id = { request.Id } not found");
            }

            return response;
        }

        [HttpPut]
        public async Task<UpdateCategoryCommandResponse> UpdateCategory([FromBody] UpdateCategoryCommandRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"UpdateCategory\" received request, id = { request.Id }");

            var response = await _mediator.Send(request, token);

            if (response.Succeed)
            {
                _logger.LogDebug($"Category was updated successfully");
            }
            else
            {
                _logger.LogDebug($"Cannot update category");
            }

            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<DeleteCategoryCommandResponse> DeleteCategory([FromHeader] DeleteCategoryCommandRequest request, CancellationToken token)
        {
            _logger.LogDebug($"Action \"DeleteCategory\" received request, id = { request.Id }");

            var response = await _mediator.Send(request, token);

            if (response.Succeed)
            {
                _logger.LogDebug($"Category was deleted successfully");
            }
            else
            {
                _logger.LogDebug($"Cannot delete category");
            }

            return response;
        }
    }
}
