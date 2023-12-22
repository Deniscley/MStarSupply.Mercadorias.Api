using MStarSupply.Application.Services;
using MStarSupply.Data.Context;
using MStarSupply.Data.Repositories;
using MStarSupply.Data.Repositories.DapperRepositories;
using MStarSupply.Data.Repositories.EFRepositories;
using MStarSupply.Domain.Interfaces.Repositories;
using MStarSupply.Domain.Interfaces.Repositories.DapperRepositories;
using MStarSupply.Domain.Interfaces.Repositories.EFRepositories;
using MStarSupply.Domain.Interfaces.Services;

namespace MStarSupply.Mercadorias.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            // Repository
            services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
            services.AddScoped<IEntradaRepository, EntradaRepository>();
            services.AddScoped<ISaidaRepository, SaidaRepository>();
            services.AddScoped<IEntradaQueriesRepository, EntradaQueriesRepository>();
            services.AddScoped<ISaidaQueriesRepository, SaidaQueriesRepository>();

            //AppServices
            services.AddScoped<IMercadoriaAppService, MercadoriaAppService>();
            services.AddScoped<IEntradaAppService, EntradaAppService>();
            services.AddScoped<ISaidaAppService, SaidaAppService>();

            // Context
            services.AddScoped<DataContext>();
        }
    }
}
