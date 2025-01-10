using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class DirecaoClinicaApiService(HttpClient httpClient)
{
    public async Task<IList<DirecaoClinicaDTO>?> GetDirecoesClinicasAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<DirecaoClinicaDTO>? direcoesClinicas = null;
        await foreach (var direcaoClinica in httpClient.GetFromJsonAsAsyncEnumerable<DirecaoClinicaDTO>("/api/DirecaoClinica", cancellationToken))
        {
            if (direcoesClinicas?.Count >= maxItems)
            {
                break;
            }
            if (direcaoClinica is not null)
            {
                direcoesClinicas ??= [];
                direcoesClinicas.Add(direcaoClinica);
            }
        }
        return direcoesClinicas;
    }
    public async Task<DirecaoClinicaDTO?> GetDirecaoClinicaByIdAsync(long direcaoClinicaId, CancellationToken cancellationToken = default)
    {
        var direcaoClinica = await httpClient.GetFromJsonAsync<DirecaoClinicaDTO>($"/api/DirecaoClinica/{direcaoClinicaId}", cancellationToken);
        return direcaoClinica;
    }
    public async Task<bool> SaveDirecaoClinicaAsync(DirecaoClinicaDTO direcaoClinica, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync($"/api/DirecaoClinica", direcaoClinica, cancellationToken);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> UpdateDirecaoClinicaAsync(DirecaoClinicaDTO direcaoClinica, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PatchAsJsonAsync($"/api/DirecaoClinica/{direcaoClinica.Id}", direcaoClinica, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}
