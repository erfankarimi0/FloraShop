using FloraShop.Application.Interfaces;
using FloraShop.Application.Services;
using FloraShop.Domain.Interfaces;
using FloraShop.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FloraShop.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application Layer
            services.AddScoped<IProductService, ProductService>();

            // Infrastructure Layer
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}