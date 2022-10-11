using Core.Application.Enums;
using Core.Application.Models;

namespace Core.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<MovieResponseModel> GetMoviesFiltered(string name, Language? lang);
    }
}
