
using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel;
using weges_v2.ApiModel.Models;

namespace weges_v2.ApiService.Data;

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
