using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Web.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoForm
{
    public EstabelecimentoDTO? Estabelecimento { get; set; } = new EstabelecimentoDTO();
    [Parameter]
    public long Id { get; set; }
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
