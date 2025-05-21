namespace ApiService.Contracts.Repositories;

public interface ISimpleRepository<T>
    where T : class
{
    IQueryable<T> GetAll();

    Task<T?> GetByIdAsync(long id);

    Task<T> AddAsync(T entity);

    Task<int> UpdateAsync(T entity);

    Task<int> DeleteAsync(T entity);
}