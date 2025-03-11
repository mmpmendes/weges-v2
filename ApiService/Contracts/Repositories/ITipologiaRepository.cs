using ApiModel.Models;

namespace ApiService.Contracts.Repositories;

public interface ITipologiaRepository : ISimpleRepository<Tipologia>
{
    Task<Tipologia> GetByNome(string nome);
}
