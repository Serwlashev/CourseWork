using MediatR;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public UpdateCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CategoryDTO category = new CategoryDTO
            {
                Id = request.Id,
                Name = request.Name
            };

            bool result = await _serviceManager.CategoryService.UpdateAsync(category);

            return new UpdateCategoryCommandResponse
            {
                Succeed = result,
                Message = result ? $"Category { category.Name } was successfully updated" : $"Cannot update category { category.Name }!"
            };
        }
    }
}
