using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public int Number { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PathToImage { get; set; }
    }
}
