using ApiModel;

using ApiService.Contracts.Repositories;

using Microsoft.EntityFrameworkCore;


namespace ApiService.Repositories;

public class SimpleRepository<T>(WegesDbContext dbContext) : ISimpleRepository<T> where T : class
{
    private readonly WegesDbContext _dbContext = dbContext;

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<int> DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return _dbContext.Set<T>().AsNoTracking();
    }

    public async Task<T?> GetByIdAsync(long id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<int> UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        return await _dbContext.SaveChangesAsync();
    }
}
