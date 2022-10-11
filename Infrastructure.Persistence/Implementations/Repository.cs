using Core.Application.Interfaces;

namespace Infrastructure.Persistence.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext context;
        public Repository(DataContext context) => this.context = context;


        public virtual async Task CreateAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }
    }
}
