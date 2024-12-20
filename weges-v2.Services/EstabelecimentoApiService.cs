﻿using System.Net.Http.Json;

using weges_v2.SharedKernel.DTO;

namespace weges_v2.Services;
public class EstabelecimentoApiService(HttpClient httpClient)
{
    public async Task<IList<EstabelecimentoDTO>?> GetEstabelecimentosAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<EstabelecimentoDTO>? estabelecimentos = null;

        await foreach (var estabelecimento in httpClient.GetFromJsonAsAsyncEnumerable<EstabelecimentoDTO>("/api/Estabelecimento", cancellationToken))
        {
            if (estabelecimentos?.Count >= maxItems)
            {
                break;
            }
            if (estabelecimento is not null)
            {
                estabelecimentos ??= [];
                estabelecimentos.Add(estabelecimento);
            }
        }

        return estabelecimentos;
    }

    public async Task<EstabelecimentoDTO?> GetEstabelecimentoByIdAsync(long estabelecimentoId, CancellationToken cancellationToken = default)
    {
        var estabelecimento = await httpClient.GetFromJsonAsync<EstabelecimentoDTO>($"/api/Estabelecimento/{estabelecimentoId}", cancellationToken);

        return estabelecimento;
    }

    public async Task<bool> SaveEstabelecimentoAsync(EstabelecimentoDTO estabelecimento, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync($"/api/Estabelecimento", estabelecimento, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateEstabelecimentoAsync(EstabelecimentoDTO estabelecimento, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PatchAsJsonAsync($"/api/Estabelecimento", estabelecimento, cancellationToken);

        return response.IsSuccessStatusCode;
    }
}
