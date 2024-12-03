using weges_v2.ApiModel.Models;

namespace weges_v2.Web.Services;

public class EntidadeApiService(HttpClient httpClient)
{
    public async Task<Entidade[]> GetEntidadesAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Entidade>? entidades = null;

        await foreach (var entidade in httpClient.GetFromJsonAsAsyncEnumerable<Entidade>("/api/Entidade", cancellationToken))
        {
            if (entidades?.Count >= maxItems)
            {
                break;
            }
            if (entidade is not null)
            {
                entidades ??= [];
                entidades.Add(entidade);
            }
        }

        return entidades?.ToArray() ?? [];
    }
}
