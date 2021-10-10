using MediatR;

namespace Services.Catalog.Presentation.Catalog.API.Features.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
