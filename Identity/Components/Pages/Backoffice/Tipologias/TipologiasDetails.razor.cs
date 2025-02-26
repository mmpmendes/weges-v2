using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace WebApp.Components.Pages.Backoffice.Tipologias;

public partial class TipologiasDetails
{
    public TipologiaDto? Tipologia { get; set; } = new TipologiaDto();
    [Parameter]
    public long Id { get; set; }
    [Inject]
    public required TipologiaApiService TipologiaApiService { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (Id >= 0)
            Tipologia = await TipologiaApiService.GetTipologiaByIdAsync(Id);
        else
            Tipologia = new TipologiaDto();
    }

    private async void SaveTipologia(MouseEventArgs e)
    {
        if (Tipologia is null)
        {
            return;
        }
        bool success = false;
        if (Id < 0)
        {
            success = await TipologiaApiService.CreateTipologiaAsync(Tipologia);
        }
        if (success)
        {
            NavigationManager.NavigateTo("/tipologias");
        }
    }

    private void GoBackToTipologias(MouseEventArgs e)
    {
        NavigationManager.NavigateTo("/tipologias");
    }
}
