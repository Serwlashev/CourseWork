using AutoMapper;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Core.Domain.Interfaces;
using System;

namespace Services.Catalog.Infrastructure.Services.Implementation
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductsService> _productService;
        private readonly Lazy<ICategoriesService> _categoryService;

        public ServiceManager(IUnitOfWork uow, IMapper mapper)
        {
            _productService = new Lazy<IProductsService>(() => new ProductsService(uow, mapper));
            _categoryService = new Lazy<ICategoriesService>(() => new CategoriesService(uow, mapper));
        }

        public IProductsService ProductService => _productService.Value;
        public ICategoriesService CategoryService => _categoryService.Value;
    }
}
