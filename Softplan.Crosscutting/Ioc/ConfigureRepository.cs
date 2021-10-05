using Microsoft.Extensions.DependencyInjection;
using Softplan.Data.Context;
using Microsoft.EntityFrameworkCore;
using Softplan.Data.Repositories;
using Softplan.Domain.Interfaces.Repositories;

namespace Softplan.Crosscutting.Ioc
{
    public static class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection servicesCollection, string connectionString, string migrationsAssemblyName, bool isDevelopment)
        {

            servicesCollection.AddDbContext<DataContext>(opt =>
            {
                if (isDevelopment) opt.EnableSensitiveDataLogging();
               
                opt.UseSqlServer(connectionString);
            });
            
            servicesCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            servicesCollection.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            servicesCollection.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
        }
    }
}
