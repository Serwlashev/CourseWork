using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.ServicesShared.Core.Interfaces.Services
{
    public interface IBaseService<TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default);
        Task<TValue> GetAsync(TKey id, CancellationToken token = default);
        Task<bool> UpdateAsync(TValue entity, CancellationToken token = default);
        Task<bool> CreateAsync(TValue entity, CancellationToken token = default);
        Task<bool> RemoveAsync(TKey id, CancellationToken token = default);
    }
}
