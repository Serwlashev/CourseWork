using Services.ServicesShared.Core.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.ServicesShared.Core.Interfaces.Repository
{
    public interface IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> GetAllAsync(CancellationToken token = default);
        Task<TValue> GetAsync(TKey id, CancellationToken token = default);
        Task CreateAsync(TValue entity, CancellationToken token = default);
        Task RemoveAsync(TValue entity, CancellationToken token = default);
        Task UpdateAsync(TValue entity, CancellationToken token = default);
    }
}
