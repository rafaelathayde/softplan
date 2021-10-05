using Microsoft.Extensions.DependencyInjection;
using Softplan.Aplication.Service;
using Softplan.Domain.Interfaces.Services;

namespace Softplan.Crosscutting.Ioc
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<ICategoryService, CategoryService>();
            servicesCollection.AddScoped<IProductService, ProductService>();
            servicesCollection.AddScoped<IPriceCalculationService, PriceCalculationService>();
        }
    }
}
