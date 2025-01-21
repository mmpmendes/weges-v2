using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Equipamentos;

public partial class EquipamentosMaster
{
    private IList<InventarioItemDTO>? InventarioItems = default!;
    private Grid<InventarioItemDTO> InventarioGrid = default!;

    private IList<ManutencaoDTO>? Manutencoes = default!;
    private Grid<ManutencaoDTO> ManutencaoGrid = default!;


    [Inject] public EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] public EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    // Note: This method is used to provide the data for the grid
    private async Task<GridDataProviderResult<InventarioItemDTO>> InventarioDataProvider(GridDataProviderRequest<InventarioItemDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        InventarioItems = await EstabelecimentoApiService.GetEstabelecimentoInventarioAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        if (InventarioItems is null)
        {
            return new GridDataProviderResult<InventarioItemDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(InventarioItems));
    }

    private async Task<GridDataProviderResult<ManutencaoDTO>> ManutencoesDataProvider(GridDataProviderRequest<ManutencaoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        Manutencoes = await EstabelecimentoApiService.GetEstabelecimentoManutencoesAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        if (Manutencoes is null)
        {
            return new GridDataProviderResult<ManutencaoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(Manutencoes));
    }
}
