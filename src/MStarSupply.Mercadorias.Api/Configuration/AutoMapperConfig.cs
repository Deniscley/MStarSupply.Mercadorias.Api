
using MStarSupply.Data.Mappings;
using MStarSupply.Data.MappingsProfile;

namespace MStarSupply.Mercadorias.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MercadoriaMappingProfile));
            services.AddAutoMapper(typeof(EntradaMappingProfile));
            services.AddAutoMapper(typeof(SaidaMappingProfile));
        }
    }
}
