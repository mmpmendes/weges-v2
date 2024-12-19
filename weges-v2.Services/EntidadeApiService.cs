using System.Net.Http.Json;

using weges_v2.SharedKernel.DTO;

namespace weges_v2.Services;

public class EntidadeApiService(HttpClient httpClient)
{
    public async Task<IList<EntidadeDTO>?> GetEntidadesAsync(int maxItems = 10, CancellationToken cancellationToken = default)
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

    public async Task<EntidadeDTO?> GetEntidadeByIdAsync(long entidadeId, CancellationToken cancellationToken = default)
    {
        var entidade = await httpClient.GetFromJsonAsync<EntidadeDTO>($"/api/Entidade/{entidadeId}", cancellationToken);

        return entidade;
    }

    public async Task<bool> SaveEntidadeAsync(EntidadeDTO entidade, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync($"/api/Entidade", entidade, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateEntidadeAsync(EntidadeDTO entidade, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PatchAsJsonAsync($"/api/Entidade", entidade, cancellationToken);

        return response.IsSuccessStatusCode;
    }
}
