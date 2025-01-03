using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Web.Components.Pages.Entidades;

public partial class EntidadeDetails
{
    [Parameter]
    public long Id { get; set; }

    public EntidadeDTO? Entidade { get; set; } = new EntidadeDTO();

    [Inject]
    public required EntidadeApiService EntidadeService { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Id >= 0)
            Entidade = await EntidadeService.GetEntidadeByIdAsync(Id);
        else
            Entidade = new EntidadeDTO();
    }


    private async void SaveEntidade(MouseEventArgs e)
    {
        if (Entidade is null)
        {
            return;
        }

        bool success;
        if (Id < 0)
        {
            success = await EntidadeService.SaveEntidadeAsync(Entidade);
        }
        else
        {
            success = await EntidadeService.UpdateEntidadeAsync(Entidade);
        }
        if (success)
        {
            NavigationManager.NavigateTo("/entidades");
        }
        //ToastMessage(success);
    }
    private void GoBackToEntidades(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/entidades");
    }

}
