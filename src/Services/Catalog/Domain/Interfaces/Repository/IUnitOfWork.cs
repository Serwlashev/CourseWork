using Services.Catalog.Core.Domain.Entity;
using System.Threading.Tasks;

namespace Services.Catalog.Core.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        IProductsRepository<long, Product> ProductsRepository { get; }
        ICategoriesRepository<long, Category> CategoriesRepository { get; }
        Task SaveChangesAsync();
    }
}
