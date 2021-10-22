using AutoMapper;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Core.Domain.Entity;
using Services.Catalog.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Services.Implementation
{
    public class ProductsService : BaseService<long, ProductDTO>, IProductsService
    {
        public ProductsService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(ProductDTO entity, CancellationToken token = default)
        {
            await _uow.ProductsRepository.CreateAsync(_mapper.Map<Product>(entity), token);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<ProductDTO> GetAsync(long id, CancellationToken token = default)
        {
            var product = await _uow.ProductsRepository.GetAsync(id, token);

            return _mapper.Map<ProductDTO>(product);
        }

        public async override Task<IEnumerable<ProductDTO>> GetAllAsync(CancellationToken token = default)
        {
            var products = await _uow.ProductsRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async override Task<bool> RemoveAsync(long id, CancellationToken token = default)
        {
            var product = await _uow.ProductsRepository.GetAsync(id, token);
            await _uow.ProductsRepository.RemoveAsync(product);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<bool> UpdateAsync(ProductDTO entity, CancellationToken token = default)
        {
            await _uow.ProductsRepository.UpdateAsync(_mapper.Map<Product>(entity), token);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async Task<IEnumerable<ProductDTO>> FindAsync(string searchText, CancellationToken token = default)
        {
            var products = await _uow.ProductsRepository.FindAsync(searchText, token);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
