using Microsoft.AspNetCore.Components;

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
    private DirecaoClinicaApiService DirecaoClinicaApiService { get; set; } = default!;

    private DirecaoClinicaDTO? DirecaoClinica { get; set; } = default!;

    //protected override async Task OnParametersSetAsync()
    //{
    //    if (DirecaoClinicaId > 0)
    //    {
    //        await DirecaoClinicaApiService.GetDirecaoClinicaByIdAsync(DirecaoClinicaId)
    //            .ContinueWith(task =>
    //            {
    //                DirecaoClinica = task.Result;
    //                StateHasChanged();
    //            });
    //    }
    //}
    private void GoBackToEstabelecimento(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void SaveDirecaoClinica(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
    {
        throw new NotImplementedException();
    }
}
