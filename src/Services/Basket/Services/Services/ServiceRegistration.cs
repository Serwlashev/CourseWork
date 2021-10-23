using Microsoft.Extensions.DependencyInjection;
using Services.Basket.Services.Services.Implementation;
using Services.Basket.Services.Services.Interfaces;
using System.Reflection;

namespace Services.Basket.Services
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddScoped<IBasketService, BasketService>();
        }
    }
}
