namespace DAL.Repositories.Interfaces;

public interface IGenericRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}