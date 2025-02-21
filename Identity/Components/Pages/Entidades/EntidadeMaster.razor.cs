using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private IList<EntidadeDTO>? Entidades = default!;
    private MudDataGrid<EntidadeDTO> EntidadesGV = default!;

    [Inject]
    public required EntidadeApiService EntidadeApiService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Entidades = await EntidadeApiService.GetEntidadesAsync();
    }

    private void NavigateToDetails(long entidadeId)
    {
        NavigationManager.NavigateTo($"/entidade/{entidadeId}");
    }

    private async Task<GridData<EntidadeDTO>> EntidadesDataProvider(GridState<EntidadeDTO> state)
    {
        if (Entidades is null)
        {
            Entidades = await EntidadeApiService.GetEntidadesAsync();
            return new GridData<EntidadeDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<EntidadeDTO>()
        {
            Items = Entidades,
            TotalItems = Entidades.Count
        };
    }

    private void AddEntidade(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }
}
