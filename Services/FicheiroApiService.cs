using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class FicheiroApiService(HttpClient httpClient)
{
    public async Task<FicheiroDTO?> CriarFicheiro(FicheiroDTO ficheiro, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("/api/Ficheiro/CriarFicheiro", ficheiro, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<FicheiroDTO>(cancellationToken: cancellationToken);
        }
        return null;
    }
}
