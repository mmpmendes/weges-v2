using Microsoft.AspNetCore.Components;

using weges_v2.Services;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.Web.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private List<EntidadeDTO>? Entidades { get; set; }
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
}
