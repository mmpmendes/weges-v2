using ApiModel.Models;

namespace ApiService.Data;

public interface ISimpleRepository<TEntity>
    where TEntity : class, IEntity<long>
{
    IQueryable<TEntity> GetAll();

    Task<TEntity> GetById(long id);

    Task Create(TEntity entity);

    Task Update(long id, TEntity entity);

    Task Delete(long id);
}