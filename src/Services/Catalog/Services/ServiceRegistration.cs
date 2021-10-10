using Microsoft.Extensions.DependencyInjection;
using Services.Catalog.Core.Application.Interfaces;
using Services.Catalog.Infrastructure.Services.Implementation;

namespace Services.Catalog.Infrastructure.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
