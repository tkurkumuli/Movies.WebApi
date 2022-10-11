using Core.Application.Interfaces.Services;
using Core.Application.Models;
using Infrastructure.ExternalServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.ExternalServices
{
    public static class ServiceExtensions
    {
        public static void AddServicesLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
            services.AddScoped<IMovieService, MovieServices>();
        }
    }
}
