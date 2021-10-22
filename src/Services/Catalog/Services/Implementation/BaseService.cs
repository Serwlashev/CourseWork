using AutoMapper;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
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

        public abstract Task<bool> CreateAsync(TValue entity, CancellationToken token = default);
        public abstract Task<TValue> GetAsync(TKey id, CancellationToken token = default);
        public abstract Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default);
        public abstract Task<bool> RemoveAsync(TKey id, CancellationToken token = default);
        public abstract Task<bool> UpdateAsync(TValue entity, CancellationToken token = default);
    }
}
