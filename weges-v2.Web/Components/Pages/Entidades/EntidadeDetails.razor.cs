using Microsoft.AspNetCore.Components;

using weges_v2.Services;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.Web.Components.Pages.Entidades;

public partial class EntidadeDetails
{
    [Parameter]
    public long Id { get; set; }

    public EntidadeDTO? entidade { get; set; }

    [Inject]
    public required EntidadeApiService EntidadeCli { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        entidade = await EntidadeCli.GetEntidadeByIdAsync(Id);
    }


}
