using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace WebApp.Components.Pages.Servico;

public partial class ServicoDetails
{
    [Parameter]
    public long EstabelecimentoId { get; set; }
    [Parameter]
    public long ServicoId { get; set; }
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;
    [Inject]
    private ServicosApiService ServicosApiService { get; set; } = default!;
    private ServicoDTO? Servico { get; set; }
    protected override async Task OnParametersSetAsync()
    {
        if (ServicoId == 0 && Servico is null)
        {
            Servico = new ServicoDTO()
            {
                EstabelecimentoId = EstabelecimentoId,
                DataInicio = DateTime.Now
            };
        }
        else
        {
            Servico = await ServicosApiService.GetServicoByIdAsync(ServicoId);
        }
    }

    private async Task SaveServico(MouseEventArgs e)
    {
        if (Servico is not null)
        {
            if (Servico.Id > 0)
            {
                await ServicosApiService.UpdateServicoAsync(Servico).ContinueWith(task =>
                {
                    if (task.IsCompletedSuccessfully)
                    {
                        GoBackToEstabelecimento(e);
                    }
                });
            }
            else
            {
                await ServicosApiService.SaveServicoAsync(Servico).ContinueWith(task =>
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
        NavigationManager.NavigateTo($"/estabelecimentos/{EstabelecimentoId}?return=servico");
    }
}
