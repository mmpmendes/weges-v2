using Microsoft.AspNetCore.Components;

using weges_v2.ApiModel.Models;
using weges_v2.Web.Services;

namespace weges_v2.Web.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private List<Entidade>? Entidades { get; set; }
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
        Entidades = (await EntidadeCli.GetEntidadesAsync()).ToList();
    }

}
