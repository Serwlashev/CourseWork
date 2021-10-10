using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Catalog.Core.Application.Interfaces
{
    public interface IBaseService<TKey, TValue>
    {
        Task<IEnumerable<TValue>> GetAllAsync();
        Task<TValue> GetAsync(TKey id);
        Task<bool> UpdateAsync(TValue entity);
        Task<bool> CreateAsync(TValue entity);
        Task<bool> RemoveAsync(TKey id);
    }
}
