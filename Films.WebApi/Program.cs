using Core.Application;
using Infrastructure.ExternalServices;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Movies.WebApi.Configurations;
using Movies.WebApi.Extensions;
using Polly;

namespace Movies.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddApplicatonLayer();
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddServicesLayer(builder.Configuration);
            builder.Services.AddThisLayer(builder.Configuration);

            builder.Services.AddControllers();

            //add httpClientfactory Config
            builder.Services.AddHttpClient("movies", client =>
            {
                client.BaseAddress = new Uri("https://imdb-api.com/api");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            })
                .AddTransientHttpErrorPolicy(x =>
                    x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(300)));
            
            var app = builder.Build();

            // auto migration
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                dataContext.Database.Migrate();
            }

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddleware();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); //swagger
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}