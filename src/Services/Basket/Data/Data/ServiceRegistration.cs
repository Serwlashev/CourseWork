using Microsoft.Extensions.DependencyInjection;
using Services.Basket.Core.Interfaces;

namespace Services.Basket.Data
{
    public static class ServiceRegistration
    {
        public static void AddDataServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
