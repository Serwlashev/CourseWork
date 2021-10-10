﻿using Services.Catalog.Core.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Core.Application.Interfaces
{
    public interface IProductsService : IBaseService<long, ProductDTO>
    {
        Task<IEnumerable<ProductDTO>> FindAsync(string searchText);
    }
}
