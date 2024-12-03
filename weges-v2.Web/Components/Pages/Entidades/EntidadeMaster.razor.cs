using Microsoft.AspNetCore.Components;

using weges_v2.Services;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.Web.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private List<EntidadeDTO>? Entidades { get; set; }
    private readonly List<string> GridTitles =
    [
        "Sigla",
        "Denominação",
        "NIF/NIPC",
        "Email"
    ];

    [Inject]
    public required EntidadeApiService EntidadeCli { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        Entidades = await EntidadeCli.GetEntidadesAsync();
    }

}
