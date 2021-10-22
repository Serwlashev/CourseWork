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
    public class CategoriesService : BaseService<long, CategoryDTO>, ICategoriesService
    {
        public CategoriesService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public async override Task<bool> CreateAsync(CategoryDTO entity, CancellationToken token = default)
        {
            await _uow.CategoriesRepository.CreateAsync(_mapper.Map<Category>(entity), token);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<CategoryDTO> GetAsync(long id, CancellationToken token = default)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id, token);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async override Task<IEnumerable<CategoryDTO>> GetAllAsync(CancellationToken token = default)
        {
            var category = await _uow.CategoriesRepository.GetAllAsync(token);

            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async override Task<bool> RemoveAsync(long id, CancellationToken token = default)
        {
            var category = await _uow.CategoriesRepository.GetAsync(id, token);
            await _uow.CategoriesRepository.RemoveAsync(category, token);
            await _uow.SaveChangesAsync(token);

            return true;
        }

        public async override Task<bool> UpdateAsync(CategoryDTO entity, CancellationToken token = default)
        {
            await _uow.CategoriesRepository.UpdateAsync(_mapper.Map<Category>(entity), token);
            await _uow.SaveChangesAsync(token);

            return true;
        }
    }
}
