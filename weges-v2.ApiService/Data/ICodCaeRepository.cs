using ApiModel.Models;

namespace ApiService.Data;

public interface ICodCaeRepository
{
    Task<CodCae> GetByIdString(string id);

    Task<IEnumerable<CodCae>?> GetCaesSecundariosByEntidadeId(long id);
}
