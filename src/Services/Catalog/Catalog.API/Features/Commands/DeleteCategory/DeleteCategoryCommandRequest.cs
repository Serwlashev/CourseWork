using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public long Id { get; set; }
    }
}
