using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Equipamentos;

public partial class EquipamentosMaster
{
    private IList<InventarioItemDTO>? InventarioItems = default!;
    private MudDataGrid<InventarioItemDTO> InventarioGrid = default!;

    private IList<ManutencaoDTO>? Manutencoes = default!;
    private MudDataGrid<ManutencaoDTO> ManutencaoGrid = default!;


    [Inject] public EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] public EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    // Note: This method is used to provide the data for the grid
    private async Task<GridData<InventarioItemDTO>> InventarioDataProvider(GridState<InventarioItemDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        //if (request.Sorting is not null && request.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = request.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        //}
        try
        {
            //InventarioItems = await EstabelecimentoApiService.GetEstabelecimentoInventarioAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (InventarioItems is null)
        {
            return new GridData<InventarioItemDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<InventarioItemDTO>()
        {
            Items = InventarioItems,
            TotalItems = InventarioItems.Count
        };
    }

    private async Task<GridData<ManutencaoDTO>> ManutencoesDataProvider(GridState<ManutencaoDTO> state)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        //if (state.Sorting is not null && state.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = state.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = state.Sorting.FirstOrDefault()!.SortDirection;
        //}

        try
        {
            //Manutencoes = await EstabelecimentoApiService.GetEstabelecimentoManutencoesAsync(EstabelecimentoService.SelectedEstabelecimento.Id, state.Filters, state.PageNumber, state.PageSize, sortString, sortDirection, state.CancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (Manutencoes is null)
        {
            return new GridData<ManutencaoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<ManutencaoDTO>()
        {
            Items = Manutencoes,
            TotalItems = Manutencoes.Count
        };
    }
}
