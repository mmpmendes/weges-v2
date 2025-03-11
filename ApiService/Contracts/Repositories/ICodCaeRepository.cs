using ApiModel.Models;

namespace ApiService.Contracts.Repositories;

public interface ICodCaeRepository
{
    Task<CodCae> GetByIdString(string id);

    Task<IEnumerable<CodCae>?> GetCaesSecundariosByEntidadeId(long id);
}
