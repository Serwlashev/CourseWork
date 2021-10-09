using Services.ServicesShared.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.ServicesShared.Core.Interfaces.Repository
{
    public interface IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task<IEnumerable<TValue>> GetAllAsync();
        Task<TValue> GetAsync(TKey id);
        void Create(TValue entity);
        void Remove(TValue entity);
        void Update(TValue entity);
    }
}
