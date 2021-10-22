using MediatR;
using Services.Catalog.Core.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly IServiceManager _serviceManager;

        public DeleteCategoryCommandHandler(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken token)
        {
            bool result = await _serviceManager.CategoryService.RemoveAsync(request.Id, token);

            return new DeleteCategoryCommandResponse
            {
                Succeed = result,
                Message = result ? $"Category was successfully removed" : $"Cannot delete category!"
            };
        }
    }
}
