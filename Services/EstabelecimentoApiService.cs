using BlazorBootstrap;

using Microsoft.AspNetCore.WebUtilities;

using SharedKernel.DTO;

using System.Net.Http.Json;

namespace Services;
public class EstabelecimentoApiService(HttpClient httpClient)
{
    public async Task<IList<EstabelecimentoDTO>?> GetEstabelecimentosAsync(IEnumerable<FilterItem> filters = default!, int pageNumber = 1, int pageSize = 0, string sortString = default!, SortDirection sortDirection = default, CancellationToken cancellationToken = default)
    {
        int maxItems = 10;
        var requestUri = $"/api/Estabelecimento";
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

    public async Task<ListEstabelecimentosDTO?> GetEstabelecimentosFiltradosAsync(IEnumerable<FilterItem> filters = default!, int pageNumber = 1, int pageSize = 0, string sortString = default!, SortDirection sortDirection = default, CancellationToken cancellationToken = default)
    {
        int maxItems = 10;
        // Convert filters to a dictionary
        var filterDict = filters?.ToDictionary(f => f.PropertyName, f => f.Value?.ToString());

        // Convert SortDirection to a string
        var sortDirectionString = sortDirection == SortDirection.Descending ? "desc" : "asc";

        // Build query parameters
        var queryParams = new Dictionary<string, string>
        {
            ["pageNumber"] = pageNumber.ToString(),
            ["pageSize"] = pageSize.ToString(),
            ["sortString"] = sortString ?? string.Empty,
            ["sortDirection"] = sortDirectionString
        };

        if (filterDict != null)
        {
            foreach (var filter in filterDict)
            {
                queryParams[filter.Key] = filter.Value!;
            }
        }

        // Construct query string
        var queryString = QueryHelpers.AddQueryString($"/api/Estabelecimento/Filtrados", queryParams);

        List<EstabelecimentoDTO>? estabelecimentos = [];

        var results = await httpClient.GetFromJsonAsync<ListEstabelecimentosDTO>(queryString, cancellationToken);

        //foreach (var estabelecimento in results.Result )
        //{
        //    if (estabelecimento is not null)
        //    {
        //        estabelecimentos ??= [];
        //        estabelecimentos.Add(estabelecimento);
        //    }
        //}
        return results;
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

    public async Task<IList<CorpoClinicoDTO>?> GetEstabelecimentoCorpoClinicoAsync(long id)
    {
        var response = await httpClient.GetFromJsonAsync<IList<CorpoClinicoDTO>>($"/api/Estabelecimento/{id}/CorpoClinico");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosCartoesNipcAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/CartoesNipc");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosAlvarasAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/Alvaras");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosMedidasAnpcAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/MedidasAnpc");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosPareceresAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/Pareceres");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentoListasVerificacao(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/ListasVerificacao");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosFicheirosAnexarAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/FicheirosAnexar");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosCartaDireitosDeveresAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/CartaDireitosDeveres");
        return response;
    }

    public async Task<IList<FicheirosLicenciamentoDTO>?> GetEstabelecimentosLicenciamentosLegaisAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<FicheirosLicenciamentoDTO>>($"/api/Estabelecimento/{id}/LicenciamentosLegais");
        return response;
    }

    public async Task<IList<InventarioItemDTO>?> GetEstabelecimentoInventarioAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<InventarioItemDTO>>($"/api/Estabelecimento/{id}/Inventario");
        return response;
    }

    public async Task<IList<ManutencaoDTO>?> GetEstabelecimentoManutencoesAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<ManutencaoDTO>>($"/api/Estabelecimento/{id}/Manutencoes");
        return response;
    }

    public async Task<IList<ColaboradorDTO>?> GetEstabelecimentoColaboradoresAsync(long id, IEnumerable<FilterItem> filters, int pageNumber, int pageSize, string sortString, SortDirection sortDirection, CancellationToken cancellationToken)
    {
        var response = await httpClient.GetFromJsonAsync<IList<ColaboradorDTO>>($"/api/Estabelecimento/{id}/Colaboradores");
        return response;
    }
}
