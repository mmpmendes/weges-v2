using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Web.Components.Pages.Servico;

public partial class ServicoDetails
{
    [Parameter]
    public long EstabelecimentoId { get; set; }
    [Parameter]
    public long ServicoId { get; set; }
    [Inject]
    private ServicosApiService ServicosApiService { get; set; } = default!;

    private ServicoDTO? Servico { get; set; } = default!;

    //protected override async Task OnParametersSetAsync()
    //{
    //    if (ServicoId > 0)
    //    {
    //        await ServicosApiService.GetServicoByIdAsync(ServicoId)
    //            .ContinueWith(task =>
    //            {
    //                Servico = task.Result;
    //                StateHasChanged();
    //            });
    //    }
    //}
    private void GoBackToEstabelecimento(MouseEventArgs e)
    {
        throw new NotImplementedException();
    }
    private void SaveServico(MouseEventArgs e)
    {
        throw new NotImplementedException();
    }
}
