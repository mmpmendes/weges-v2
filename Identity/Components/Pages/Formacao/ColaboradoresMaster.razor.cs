using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Formacao;

public partial class ColaboradoresMaster
{
    private IList<ColaboradorDTO>? ColaboradoresItems = default!;
    private MudDataGrid<ColaboradorDTO> ColaboradoresGrid = default!;

    [Inject] public EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] public EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    // Note: This method is used to provide the data for the grid
    private async Task<GridData<ColaboradorDTO>> ColaboradoresDataProvider(GridState<ColaboradorDTO> state)
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
            //ColaboradoresItems = await EstabelecimentoApiService.GetEstabelecimentoColaboradoresAsync(EstabelecimentoService.SelectedEstabelecimento.Id, state.Filters, state.PageNumber, state.PageSize, sortString, sortDirection, state.CancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (ColaboradoresItems is null)
        {
            return new GridData<ColaboradorDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<ColaboradorDTO>()
        {
            Items = ColaboradoresItems,
            TotalItems = ColaboradoresItems.Count
        };
    }
}
