using ServicesShared.Core.Models;

namespace Services.Catalog.Core.Domain.Interfaces.Repository
{
    public interface ICategoriesRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
    }
}
