namespace Services.Catalog.Core.Application.Interfaces
{
    public interface IServiceManager
    {
        IProductsService ProductService { get; }
        ICategoriesService CategoryService { get; }
    }
}
