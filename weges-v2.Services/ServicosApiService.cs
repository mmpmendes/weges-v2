using System.Net.Http.Json;

using weges_v2.SharedKernel.DTO;

namespace weges_v2.Services;
public class ServicosApiService(HttpClient httpClient)
{
    public async Task<IList<ServicoDTO>?> GetServicosAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<ServicoDTO>? servicos = null;
        await foreach (var servico in httpClient.GetFromJsonAsAsyncEnumerable<ServicoDTO>("/api/Servicos", cancellationToken))
        {
            if (servicos?.Count >= maxItems)
            {
                break;
            }
            if (servico is not null)
            {
                servicos ??= [];
                servicos.Add(servico);
            }
        }
        return servicos;
    }
    public async Task<ServicoDTO?> GetServicoByIdAsync(long servicoId, CancellationToken cancellationToken = default)
    {
        var servico = await httpClient.GetFromJsonAsync<ServicoDTO>($"/api/Servicos/{servicoId}", cancellationToken);
        return servico;
    }
    public async Task<bool> SaveServicoAsync(ServicoDTO servico, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync($"/api/Servicos", servico, cancellationToken);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> UpdateServicoAsync(ServicoDTO servico, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PatchAsJsonAsync($"/api/Servicos", servico, cancellationToken);
        return response.IsSuccessStatusCode;
    }

}
