using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Services.Catalog.Core.Application
{
    static public class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
