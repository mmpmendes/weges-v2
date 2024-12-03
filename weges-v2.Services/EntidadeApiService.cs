using System.Net.Http.Json;

using weges_v2.SharedKernel.DTO;

namespace weges_v2.Services;

public class EntidadeApiService(HttpClient httpClient)
{
    public async Task<List<EntidadeDTO>> GetEntidadesAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<EntidadeDTO>? entidades = null;

        await foreach (var entidade in httpClient.GetFromJsonAsAsyncEnumerable<EntidadeDTO>("/api/Entidade", cancellationToken))
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

        return entidades;
    }
}
