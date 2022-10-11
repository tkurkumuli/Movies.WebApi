using Movies.WebApi.Configurations;

namespace Movies.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddThisLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerServices();
        }
    }
}
