namespace Parking.DAL.Interface;

public interface IGenericRepository<TEntity,TId> where TEntity:class
{
    Task Create(TEntity entity);
    Task<IEnumerable<TEntity>> Get();
    Task<TEntity> GetById(TId id);
    Task Update(TEntity entity);
    Task Delete(TId id);
}