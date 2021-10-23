using Services.Catalog.Core.Application.DTO;
using Services.ServicesShared.Core.Interfaces.Services;

namespace Services.Catalog.Core.Application.Interfaces
{
    public interface ICategoriesService : IBaseService<long, CategoryDTO>
    {
    }
}
