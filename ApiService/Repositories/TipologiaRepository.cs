using ApiModel;
using ApiModel.Models;
using ApiService.Contracts.Repositories;

using Microsoft.EntityFrameworkCore;

namespace ApiService.Repositories;

public class TipologiaRepository(WegesDbContext dbContext) : SimpleRepository<Tipologia>(dbContext), ITipologiaRepository
{
    private readonly WegesDbContext _dbContext = dbContext;
    public async Task<Tipologia> GetByNome(string nome)
    {
        var tipologia = await _dbContext.Tipologias.FirstOrDefaultAsync(t => t.Nome.Equals(nome));

        return tipologia;
    }
}
