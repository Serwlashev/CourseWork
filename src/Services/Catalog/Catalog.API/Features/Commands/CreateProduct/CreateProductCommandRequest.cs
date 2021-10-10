using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public int Number { get; set; }
    }
}
