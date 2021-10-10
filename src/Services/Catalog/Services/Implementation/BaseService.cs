using AutoMapper;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Services.Implementation
{
    public abstract class BaseService<TKey, TValue> : IBaseService<TKey, TValue>
    {
        protected IUnitOfWork _uow;
        protected IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public abstract Task<bool> CreateAsync(TValue entity);
        public abstract Task<TValue> GetAsync(TKey id);
        public abstract Task<IEnumerable<TValue>> GetAllAsync();
        public abstract Task<bool> RemoveAsync(TKey id);
        public abstract Task<bool> UpdateAsync(TValue entity);
    }
}
