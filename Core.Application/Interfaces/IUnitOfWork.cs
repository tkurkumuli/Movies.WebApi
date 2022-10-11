using Core.Application.Interfaces.Repositories;

namespace Core.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }
        Task<int> SaveAsync();
    }
}
