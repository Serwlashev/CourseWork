using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<DeleteProductCommandResponse>
    {
        public long Id { get; set; }
    }
}
