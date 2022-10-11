using Core.Application.Interfaces;
using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistence.Implementations.Repositories;

namespace Infrastructure.Persistence.Implementations
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }

        private IMovieRepository? movieRepository;
        public IMovieRepository MovieRepository => movieRepository ??= new MovieRepository(context);
        public async Task<int> SaveAsync() => await context.SaveChangesAsync();
    }
}
