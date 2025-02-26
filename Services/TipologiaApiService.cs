using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class TipologiaApiService(HttpClient httpClient)
{
    public async Task<IList<TipologiaDto>?> GetTipologiasAsync(CancellationToken cancellationToken = default)
    {
        List<TipologiaDto>? tipologias = null;
        await foreach (var tipologia in httpClient.GetFromJsonAsAsyncEnumerable<TipologiaDto>("/api/Tipologias", cancellationToken))
        {
            if (tipologia is not null)
            {
                tipologias ??= [];
                tipologias.Add(tipologia);
            }
        }
        return tipologias;
    }

    public static async Task<IList<TipologiaDto>?> GetTipologiasAsync(object filters, int pageNumber, int pageSize, string? sortString, string sortDirection)
    {
        throw new NotImplementedException();
    }

    public async Task<TipologiaDto?> GetTipologiaByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await httpClient.GetFromJsonAsync<TipologiaDto>($"/api/Tipologias/{id}", cancellationToken);
    }

    public async Task<bool> CreateTipologiaAsync(TipologiaDto tipologia, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/Tipologias", tipologia, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}
