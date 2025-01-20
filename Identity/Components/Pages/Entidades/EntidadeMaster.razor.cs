using BlazorBootstrap;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private IList<EntidadeDTO>? Entidades = default!;
    private Grid<EntidadeDTO> EntidadesGV = default!;

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

    private async Task<GridDataProviderResult<EntidadeDTO>> EntidadesDataProvider(GridDataProviderRequest<EntidadeDTO> request)
    {
        if (Entidades is null)
            Entidades = await EntidadeApiService.GetEntidadesAsync();

        return await Task.FromResult(request.ApplyTo(Entidades));
    }

    private void AddEntidade(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }
}
