using AutoMapper;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Core.Domain.Entity;
using Services.Catalog.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Services.Implementation
{
    public class CategoriesService : BaseService<long, CategoryDTO>, ICategoriesService
    {
        public CategoriesService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(CategoryDTO entity)
        {
            _uow.CategoriesRepository.Create(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<CategoryDTO> GetAsync(long id)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async override Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var category = await _uow.CategoriesRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async override Task<bool> RemoveAsync(long id)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id);
            _uow.CategoriesRepository.Remove(category);
            await _uow.SaveChangesAsync();

            return true;
        }

        public async override Task<bool> UpdateAsync(CategoryDTO entity)
        {
            _uow.CategoriesRepository.Update(_mapper.Map<Category>(entity));
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
