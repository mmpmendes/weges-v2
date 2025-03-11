
using Microsoft.EntityFrameworkCore;

using ApiModel;
using ApiModel.Models;
using ApiService.Contracts.Repositories;

namespace ApiService.Repositories;

public class CodCaeRepository(WegesDbContext dbContext) : SimpleRepository<CodCae>(dbContext), ICodCaeRepository
{
    private readonly WegesDbContext _dbContext = dbContext;

    public async Task<CodCae> GetByIdString(string codigo)
    {
        var entity = await _dbContext.Set<CodCae>()
            .AsNoTracking()
            .FirstOrDefaultAsync(cod => cod.Codigo == codigo);

        return entity;
    }

    public async Task<IEnumerable<CodCae>?> GetCaesSecundariosByEntidadeId(long entidadeId)
    {
        var entidade = await _dbContext.Set<Entidade>().Where(ee => ee.Id == entidadeId).FirstOrDefaultAsync();

        if (entidade == null)
            return null;
        return entidade.CodCaes;
    }
}
