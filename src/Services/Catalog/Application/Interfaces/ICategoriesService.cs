using Services.Catalog.Core.Application.DTO;

namespace Services.Catalog.Core.Application.Interfaces
{
    public interface ICategoriesService : IBaseService<long, CategoryDTO>
    {
    }
}
