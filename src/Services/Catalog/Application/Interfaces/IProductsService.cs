using Services.Catalog.Core.Application.DTO;
using Services.ServicesShared.Core.Interfaces.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Core.Application.Interfaces
{
    public interface IProductsService : IBaseService<long, ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> FindAsync(string searchText, CancellationToken token = default);
    }
}
