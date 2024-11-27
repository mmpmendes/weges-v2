using weges_v2.ApiModel.Models;

namespace weges_v2.ApiService.Data;

public interface ICodCaeRepository
{
    Task<CodCae> GetByIdString(string id);

    Task<IEnumerable<CodCae>?> GetCaesSecundariosByEntidadeId(long id);
}
