using AutoMapper;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Core.Domain.Entity;
using Services.Catalog.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Services.Implementation
{
    public class ProductsService : BaseService<long, ProductDTO>, IProductsService
    {
        public ProductsService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(ProductDTO entity)
        {
            _uow.ProductsRepository.Create(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<ProductDTO> GetAsync(long id)
        {
            var product = await _uow.ProductsRepository.GetAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async override Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _uow.ProductsRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async override Task<bool> RemoveAsync(long id)
        {
            var product = await _uow.ProductsRepository.GetAsync(id);
            _uow.ProductsRepository.Remove(product);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(ProductDTO entity)
        {
            _uow.ProductsRepository.Update(_mapper.Map<Product>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProductDTO>> FindAsync(string searchText)
        {
            var products = await _uow.ProductsRepository.FindAsync(searchText);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
