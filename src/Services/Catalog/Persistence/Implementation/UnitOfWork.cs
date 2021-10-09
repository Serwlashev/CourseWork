using Services.Catalog.Core.Domain.Entity;
using Services.Catalog.Core.Domain.Interfaces;
using Services.Catalog.Core.Domain.Interfaces.Repository;
using Services.Catalog.Infrastructure.Persistence.Implementation.Repositories;
using System.Threading.Tasks;

namespace Services.Catalog.Infrastructure.Persistence.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationContext;
        private ICategoriesRepository<long, Category> _categoriesRepository;
        private IProductsRepository<long, Product> _productsRepository;

        public IProductsRepository<long, Product> ProductsRepository
            => _productsRepository ??= new ProductsRepository(_applicationContext);
        public ICategoriesRepository<long, Category> CategoriesRepository
            => _categoriesRepository ??= new CategoriesRepository(_applicationContext);

        public UnitOfWork(ApplicationDbContext context)
        {
            _applicationContext = context;
        }

        public async Task SaveChangesAsync()
            => await _applicationContext.SaveChangesAsync();
    }
}
