using Microsoft.OpenApi.Models;

namespace Movies.WebApi.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies.WebApi", Version = "v1" });
            });
        }

        public static IApplicationBuilder UseSwaggerMiddleware(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.WebApi");
                c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
            });
            return app;
        }
    }
}
