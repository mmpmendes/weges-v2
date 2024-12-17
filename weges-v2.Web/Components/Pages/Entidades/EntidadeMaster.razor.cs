using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

using weges_v2.Services;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.Web.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private IList<EntidadeDTO>? Entidades = default!;
    private HashSet<EntidadeDTO> EntidadesSelecionadas = new();

    private readonly List<string> GridTitles =
    [
        "",
        "Sigla",
        "Denominação",
        "NIF/NIPC",
        "Email"
    ];

    [Inject]
    public required EntidadeApiService EntidadeCli { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Entidades = await EntidadeCli.GetEntidadesAsync();
    }

    private void NavigateToDetails(long entidadeId)
    {
        NavigationManager.NavigateTo($"/entidade/{entidadeId}");
    }

    private async Task<GridDataProviderResult<EntidadeDTO>> EntidadesDataProvider(GridDataProviderRequest<EntidadeDTO> request)
    {
        if (Entidades is null)
            Entidades = await EntidadeCli.GetEntidadesAsync();

        return await Task.FromResult(request.ApplyTo(Entidades));
    }

    private Task OnSelectedItemsChanged(HashSet<EntidadeDTO> entidades)
    {
        EntidadesSelecionadas = entidades is not null && entidades.Count == 0 ? entidades : new();
        return Task.CompletedTask;
    }
}
