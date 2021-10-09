using Microsoft.Extensions.DependencyInjection;
using Services.Catalog.Core.Domain.Interfaces;
using Services.Catalog.Infrastructure.Persistence.Implementation;

namespace Services.Catalog.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
