using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
