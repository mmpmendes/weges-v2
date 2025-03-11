using ApiModel.Models;

namespace ApiService.Contracts.Repositories;

public interface ISimpleRepository<T>
    where T : class, IEntity<long>
{
    IQueryable<T> GetAll();

    Task<T> GetById(long id);

    Task Create(T entity);

    Task Update(long id, T entity);

    Task Delete(long id);
}