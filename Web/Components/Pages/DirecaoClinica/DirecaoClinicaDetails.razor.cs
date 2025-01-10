using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Web.Components.Pages.DirecaoClinica;

public partial class DirecaoClinicaDetails
{
    [Parameter]
    public long EstabelecimentoId { get; set; }
    [Parameter]
    public long DirecaoClinicaId { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;
    [Inject]
    private DirecaoClinicaApiService DirecaoClinicaApiService { get; set; } = default!;

    private DirecaoClinicaDTO? DirecaoClinica { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (DirecaoClinicaId == 0 && DirecaoClinica is null)
        {
            DirecaoClinica = new DirecaoClinicaDTO()
            {
                EstabelecimentoId = EstabelecimentoId,
                ValidadeIdentificacao = DateOnly.FromDateTime(DateTime.Now)
            };
        }
        else
        {
            DirecaoClinica = await DirecaoClinicaApiService.GetDirecaoClinicaByIdAsync(DirecaoClinicaId);
        }
    }

    private async Task SaveDirecaoClinica(MouseEventArgs e)
    {
        if (DirecaoClinica is not null)
        {
            if (DirecaoClinica.Id > 0)
            {
                await DirecaoClinicaApiService.UpdateDirecaoClinicaAsync(DirecaoClinica).ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        GoBackToEstabelecimento(e);
                    }
                });
            }
            else
            {
                await DirecaoClinicaApiService.SaveDirecaoClinicaAsync(DirecaoClinica).ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        GoBackToEstabelecimento(e);
                    }
                });
            }
        }
    }
    private void GoBackToEstabelecimento(MouseEventArgs e)
    {
        NavigationManager.NavigateTo($"/estabelecimentos/{EstabelecimentoId}?return=dircli");
    }
}
