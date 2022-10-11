using Core.Domain.Entities;

namespace Core.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task CreateUser2MovieAsync(User2Movie user2Movie);
        Task<IEnumerable<Movie>> GetWatchListByUserAsync(Guid userId);
        Task<User2Movie?> GetUser2movieByIdAsync(Guid id);
    }
}
