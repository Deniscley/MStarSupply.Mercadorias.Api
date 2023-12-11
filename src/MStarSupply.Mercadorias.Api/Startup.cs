
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using MStarSupply.Data.Context;
using MStarSupply.Mercadorias.Api.Configuration;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace MStarSupply.Mercadorias.Api
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAutoMapperConfiguration();

            services.AddDatabaseConfiguration(Configuration);

            services.AddDependencyInjectionConfiguration();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Supply Chain",
                    Version = "v1",
                    Description = "API of the Supply Chain application.", });
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            app.UseExceptionHandler("/error");

            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseDatabaseConfiguration();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options =>
            {
                options
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            });

            app.UseAuthorization();

            app.MapControllers();
        }
    }
    public interface IStartup
    {
        IConfiguration Configuration { get; }
        void Configure(WebApplication app, IWebHostEnvironment environment);
        void ConfigureServices(IServiceCollection services);

    }

    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder WebAppBuilder) where TStartup : IStartup
        {
            var startup = Activator.CreateInstance(typeof(TStartup), WebAppBuilder.Configuration) as IStartup;
            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(WebAppBuilder.Services);

            var app = WebAppBuilder.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return WebAppBuilder;
        }
    }
}
