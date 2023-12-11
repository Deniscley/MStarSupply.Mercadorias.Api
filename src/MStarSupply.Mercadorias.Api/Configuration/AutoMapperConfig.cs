
using MStarSupply.Data.Mappings;

namespace MStarSupply.Mercadorias.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MercadoriaMappingProfile));
    }
    }
}
