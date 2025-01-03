using Microsoft.EntityFrameworkCore;

using ApiModel;
using ApiModel.Models;


namespace ApiService.Data;

public class SimpleRepository<T>(WegesDbContext dbContext) : ISimpleRepository<T> where T : class, IEntity<long>
{
    private readonly WegesDbContext _dbContext = dbContext;

    public async Task Create(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return;
        }

        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return _dbContext.Set<T>().AsNoTracking();
    }

    public async Task<T> GetById(long id)
    {
        var entity = await _dbContext.Set<T>()
        .AsNoTracking()
        .FirstOrDefaultAsync(e => e.Id.Equals(id));

        if (entity == null)
        {
            throw new KeyNotFoundException($"Entidade com o id {id} não foi encontrada.");
        }
        return entity;
    }

    public async Task Update(long id, T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}
