namespace Core.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity entity);
    }
}
