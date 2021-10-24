using Microsoft.Extensions.DependencyInjection;
using Services.Basket.Core.Interfaces;
using Services.Basket.Core.Interfaces.Repositories;
using Services.Basket.Data.Repositories;

namespace Services.Basket.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IBasketRepository, BasketRepository>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
