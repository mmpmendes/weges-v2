using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class TipologiaApiService(HttpClient httpClient)
{
    public async Task<IList<TipologiaDTO>?> GetTipologiasAsync(CancellationToken cancellationToken = default)
    {
        List<TipologiaDTO>? tipologias = null;
        await foreach (var tipologia in httpClient.GetFromJsonAsAsyncEnumerable<TipologiaDTO>("/api/Tipologias", cancellationToken))
        {
            if (tipologia is not null)
            {
                tipologias ??= [];
                tipologias.Add(tipologia);
            }
        }
        return tipologias;
    }

    public async Task<TipologiaDTO?> GetTipologiaByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<TipologiaDTO>($"/api/Tipologias/{id}", cancellationToken);
    }

    public async Task<bool> CreateTipologiaAsync(TipologiaDTO tipologia, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/Tipologias", tipologia, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}
