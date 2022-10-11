using Core.Application.Enums;
using Core.Application.Interfaces.Services;
using Core.Application.Models;
using Infrastructure.ExternalServices.Extensions;
using Microsoft.Extensions.Options;

namespace Infrastructure.ExternalServices.Services
{
    public class MovieServices : IMovieService
    {
        private readonly ApiSettings apiSettings;
        private readonly IHttpClientFactory clientFactory;
        public MovieServices(IHttpClientFactory clientFactory, IOptions<ApiSettings> apiSettings)
        {
            this.clientFactory = clientFactory;
            this.apiSettings = apiSettings.Value;
        }

        public async Task<MovieResponseModel?> GetMoviesFiltered(string name, Language? lang)
        {
            var httpClient = clientFactory.CreateClient("movies");
            var result = await httpClient.GetAsync($"/{lang}/API/SearchMovie/{apiSettings.ApiKey}/{name}");
            return await result.ReadContentAs<MovieResponseModel>();
        }
    }
}
