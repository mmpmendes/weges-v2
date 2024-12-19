using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using weges_v2.Services;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.Web.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoDetails
{
    [Parameter]
    public long Id { get; set; }

    public EstabelecimentoDTO? Estabelecimento { get; set; } = new EstabelecimentoDTO();

    [Inject]
    public required EstabelecimentoApiService EstabelecimentoService { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Id >= 0)
            Estabelecimento = await EstabelecimentoService.GetEstabelecimentoByIdAsync(Id);
        else
            Estabelecimento = new EstabelecimentoDTO();
    }


    private async void SaveEstabelecimento(MouseEventArgs e)
    {
        if (Estabelecimento is null)
        {
            return;
        }

        bool success;
        if (Id < 0)
        {
            success = await EstabelecimentoService.SaveEstabelecimentoAsync(Estabelecimento);
        }
        else
        {
            success = await EstabelecimentoService.UpdateEstabelecimentoAsync(Estabelecimento);
        }
        if (success)
        {
            NavigationManager.NavigateTo("/estabelecimentos");
        }
    }
    private void GoBackToEstabelecimentos(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/estabelecimentos");
    }
}
