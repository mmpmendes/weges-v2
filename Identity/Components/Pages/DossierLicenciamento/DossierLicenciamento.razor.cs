using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.DossierLicenciamento;

public partial class DossierLicenciamento
{
    [Inject] EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    private IList<FicheirosLicenciamentoDTO>? CartoesNipc = default!;
    private Grid<FicheirosLicenciamentoDTO> CartoesNipcGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? Alvaras = default!;
    private Grid<FicheirosLicenciamentoDTO> AlvarasGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? MedidasAnpc = default!;
    private Grid<FicheirosLicenciamentoDTO> MedidasAnpcGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? PareceresAnpc = default!;
    private Grid<FicheirosLicenciamentoDTO> PareceresAnpcGrid = default!;

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> CartaoNipcDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
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
            CartoesNipc = await EstabelecimentoApiService.GetEstabelecimentosCartoesNipcAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (CartoesNipc is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(CartoesNipc));
    }

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> AlvarasDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
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
            Alvaras = await EstabelecimentoApiService.GetEstabelecimentosAlvarasAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (Alvaras is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(Alvaras));
    }

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> MedidasAnpcDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
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
            MedidasAnpc = await EstabelecimentoApiService.GetEstabelecimentosMedidasAnpcAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (MedidasAnpc is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(MedidasAnpc));
    }

    private async Task<GridDataProviderResult<FicheirosLicenciamentoDTO>> PareceresAnpcDataProvider(GridDataProviderRequest<FicheirosLicenciamentoDTO> request)
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
            PareceresAnpc = await EstabelecimentoApiService.GetEstabelecimentosPareceresAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (PareceresAnpc is null)
        {
            return new GridDataProviderResult<FicheirosLicenciamentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(PareceresAnpc));
    }
}
