using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace WebApp.Components.Pages.DirecaoClinica;

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

    private IEnumerable<TipologiaDto>? Tipologias { get; set; }

    private DirecaoClinicaDTO? DirecaoClinica { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        if (DirecaoClinicaId == 0 && DirecaoClinica is null)
        {
            DirecaoClinica = new DirecaoClinicaDTO()
            {
                EstabelecimentoId = EstabelecimentoId,
                ValidadeIdentificacao = DateTime.Now
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

    private async Task<IEnumerable<string?>> Search(string value, CancellationToken token)
    {
        await Task.Delay(5);

        if (Tipologias is not null && Tipologias.Any())
        {
            var results = string.IsNullOrEmpty(value)
                ? Tipologias.Select(x => x.Nome).ToList()
                : Tipologias.Where(x => x.Nome.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                            .Select(x => x.Nome)
                            .ToList();

            // If there are no matches and value is not null or empty, add it to the results
            if (!results.Any() && !string.IsNullOrEmpty(value))
            {
                results.Add(value);
            }

            return results;
        }

        return new List<string> { value };
    }
}
