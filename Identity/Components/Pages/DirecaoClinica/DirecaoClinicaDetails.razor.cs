using BlazorBootstrap;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.DirecaoClinica;

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
    [Inject]
    private TipologiaApiService TipologiaApiService { get; set; } = default!;

    private IEnumerable<TipologiaDTO>? Tipologias { get; set; }

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

        if (Tipologias is null)
        {
            Tipologias = await TipologiaApiService.GetTipologiasAsync();
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

    private async Task<AutoCompleteDataProviderResult<TipologiaDTO>> TipologiasDataProvider(AutoCompleteDataProviderRequest<TipologiaDTO> request)
    {
        if (Tipologias is null)
        {
            Tipologias = await TipologiaApiService.GetTipologiasAsync();
        }

        if (Tipologias is not null)
        {
            return await Task.FromResult(request.ApplyTo(Tipologias.OrderBy(tipologia => tipologia.Nome)));
        }
        return new AutoCompleteDataProviderResult<TipologiaDTO>();
    }

    private void OnAutoCompleteChanged(TipologiaDTO tipologia)
    {
        Console.WriteLine($"'{tipologia?.Nome}' selected.");
    }
}
