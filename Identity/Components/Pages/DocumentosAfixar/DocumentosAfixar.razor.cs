using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.DocumentosAfixar;

public partial class DocumentosAfixar
{
    [Inject] EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    private IList<FicheirosLicenciamentoDTO>? ListasVerificacao = default!;
    private Grid<FicheirosLicenciamentoDTO> ListaVerificacaoGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? FicheirosAnexar = default!;
    private Grid<FicheirosLicenciamentoDTO> FicheirosAnexarGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? CartasDireitosDeveres = default!;
    private Grid<FicheirosLicenciamentoDTO> CartaDireitosDeveresGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? LicenciamentosRegistosLegais = default!;
    private Grid<FicheirosLicenciamentoDTO> LicenciamentoRegistoLegalGrid = default!;

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> ListaVerificacaoDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        try
        {
            ListasVerificacao = await EstabelecimentoApiService.GetEstabelecimentoListasVerificacao(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (ListasVerificacao is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(ListasVerificacao));
    }

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> FicheirosAnexarDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        try
        {
            FicheirosAnexar = await EstabelecimentoApiService.GetEstabelecimentosFicheirosAnexarAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (FicheirosAnexar is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(FicheirosAnexar));
    }

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> CartaDireitosDeveresDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        try
        {
            CartasDireitosDeveres = await EstabelecimentoApiService.GetEstabelecimentosCartaDireitosDeveresAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (CartasDireitosDeveres is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(CartasDireitosDeveres));
    }

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> LicenciamentoRegistoLegalDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }
        try
        {
            LicenciamentosRegistosLegais = await EstabelecimentoApiService.GetEstabelecimentosLicenciamentosLegaisAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (LicenciamentosRegistosLegais is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(LicenciamentosRegistosLegais));
    }
}
