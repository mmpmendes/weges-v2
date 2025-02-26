using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace WebApp.Components.Pages.Backoffice.Tipologias;

public partial class TipologiasMaster
{
    private IList<TipologiaDto>? Tipologias = default!;
    private MudDataGrid<TipologiaDto> TipologiasGrid = default!;
    [Inject]
    public required NavigationManager NavigationManager { get; set; } = default!;
    [Inject]
    public required TipologiaApiService TipologiaApiService { get; set; } = default!;

    private async Task<GridData<TipologiaDto>> TipologiasDataProvider(GridState<TipologiaDto> state)
    {
        Tipologias = await TipologiaApiService.GetTipologiasAsync(
            filters: state.FilterDefinitions,
            pageNumber: state.Page + 1,
            pageSize: state.PageSize,
            sortString: state.SortDefinitions.FirstOrDefault()?.SortBy,
            sortDirection: state.SortDefinitions.FirstOrDefault()?.Descending == true ? "desc" : "asc");

        if (Tipologias is null)
        {
            return new GridData<TipologiaDto>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<TipologiaDto>()
        {
            Items = Tipologias,
            TotalItems = Tipologias.Count
        };
    }

    private void NavigateToDetails(long tipologiaId)
    {
        NavigationManager.NavigateTo($"/tipologias/{tipologiaId}");
    }

    private void AddTipologia(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }
}
