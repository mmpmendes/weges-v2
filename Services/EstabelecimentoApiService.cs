using BlazorBootstrap;

using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class EstabelecimentoApiService(HttpClient httpClient)
{
    public async Task<IList<EstabelecimentoDTO>?> GetEstabelecimentosAsync(IEnumerable<FilterItem> filters = default!, int pageNumber = 1, int pageSize = 0, string sortString = default!, SortDirection sortDirection = default, CancellationToken cancellationToken = default)
    {
        int maxItems = 10;
        //var queryParameters = new Dictionary<string, string>
        //{
        //    { "maxItems", maxItems.ToString() },
        //    { "pageSize", pageSize.ToString() },
        //    { "sortString", sortString },
        //    { "sortDirection", sortDirection.ToString() }
        //};

        //if (filters != null)
        //{
        //    foreach (var filter in filters)
        //    {
        //        queryParameters.Add($"filters[{filter.}]", filter.Value);
        //    }
        //}

        //var queryString = string.Join("&", queryParameters.Select(kvp => $"{kvp.Key}={Uri.EscapeDataString(kvp.Value)}"));
        var requestUri = $"/api/Estabelecimento";//?{queryString}";
        List<EstabelecimentoDTO>? estabelecimentos = null;

        await foreach (var estabelecimento in httpClient.GetFromJsonAsAsyncEnumerable<EstabelecimentoDTO>(requestUri, cancellationToken))
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

    public async Task<bool> UploadCertificadoAsync(MultipartFormDataContent data, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync($"/api/Estabelecimento/UploadCertificado", data, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UploadLicencaAsync(MultipartFormDataContent data, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync($"/api/Estabelecimento/UploadCertificado", data, cancellationToken);

        return response.IsSuccessStatusCode;
    }

    public async Task<CertificadoErsDTO?> GetEstabelecimentoCertificadoErsAsync(long id)
    {
        var response = await httpClient.GetFromJsonAsync<CertificadoErsDTO>($"/api/Estabelecimento/{id}/CertificadoErs");
        return response;
    }

    public async Task<LicencaErsDTO?> GetEstabelecimentoLicencaErsAsync(long id)
    {
        var response = await httpClient.GetFromJsonAsync<LicencaErsDTO>($"/api/Estabelecimento/{id}/LicencaErs");
        return response;
    }

    public async Task<IList<ServicoDTO>?> GetEstabelecimentoServicosAsync(long id)
    {
        var response = await httpClient.GetFromJsonAsync<IList<ServicoDTO>>($"/api/Estabelecimento/{id}/Servicos");
        return response;
    }

    public async Task<IList<DirecaoClinicaDTO>?> GetEstabelecimentoDirecoesClinicasAsync(long id)
    {
        var response = await httpClient.GetFromJsonAsync<IList<DirecaoClinicaDTO>>($"/api/Estabelecimento/{id}/DirecoesClinicas");
        return response;
    }
}
