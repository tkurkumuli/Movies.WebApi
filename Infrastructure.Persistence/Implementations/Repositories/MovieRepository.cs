using Core.Application.Interfaces.Repositories;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Implementations.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext context) : base(context) { }

        public virtual async Task CreateUser2MovieAsync(User2Movie user2Movie)
        {
            await context.User2Movies.AddAsync(user2Movie);
        }
        public async Task<IEnumerable<Movie>> GetWatchListByUserAsync(Guid userId)
        {
            return await  (from m in context.Movies
                          join u2m in context.User2Movies
                          on m.Id equals u2m.MovieId
                          where u2m.UserId == userId
                          select new Movie
                          {
                              Id = m.Id,
                              ResultType = m.ResultType,
                              ImagePath = m.ImagePath,
                              Title = m.Title,
                              Description = m.Description
                          }).ToListAsync();
        }
        public async Task<User2Movie?> GetUser2movieByIdAsync(Guid id)
        {
            return await context.User2Movies.FindAsync(id);
        }
    }
}
