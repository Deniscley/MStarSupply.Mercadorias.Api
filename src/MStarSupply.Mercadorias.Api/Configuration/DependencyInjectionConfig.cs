using MStarSupply.Application.Services;
using MStarSupply.Data.Context;
using MStarSupply.Data.Repositories;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();

            //AppServices
            services.AddScoped<IMercadoriaAppServices, MercadoriaAppServices>();

            // Context
            services.AddScoped<DataContext>();
        }
    }
}
