using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using Services;
using Services.Models;

using SharedKernel.DTO;

using WebApp.InMemory;

namespace WebApp.Components.Pages.DossierLicenciamento;

public partial class DossierLicenciamento
{
    [Parameter] public long estabelecimentoId { get; set; }
    [Inject] EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] EstabelecimentoService EstabelecimentoService { get; set; } = default!;
    [Inject] private FicheiroApiService FicheiroApiService { get; set; } = default!;

    [Inject] private IJSRuntime jSRuntime { get; set; } = default!;

    private AnexoDTO? CartaoNipc { get; set; }
    private bool IsCartaoNipcSelected { get; set; }
    public IBrowserFile? selectedCartaoNipcFile = default!;

    private async Task UploadCartaoNipc()
    {
        // TODO: Output mensagem de erro tentar de novo
        if (selectedCartaoNipcFile is null) return;

        using var formData = new MultipartFormDataContent();

        var stream = FileManagementClientSide.SetupFileForUpload(selectedCartaoNipcFile);

        // TODO: Output mensagem de erro tentar de novo
        if (stream is null) return;

        formData.Add(stream, "file", selectedCartaoNipcFile.Name);

        FicheiroDTO? ficheiro = await EstabelecimentoApiService.UploadFicheiroAsync(formData);
        IsCartaoNipcSelected = false;

        if (ficheiro is not null)
        {
            CartaoNipc!.FicheiroId = ficheiro.Id;
            CartaoNipc!.EstabelecimentoId = estabelecimentoId;
        }
        if (CartaoNipc!.Id <= 0)
        {
            await EstabelecimentoApiService.CreateCartaoNipcAsync(estabelecimentoId, CartaoNipc);
        }
        else
        {
            await EstabelecimentoApiService.UpdateCartaoNipcAsync(estabelecimentoId, CartaoNipc);
        }
    }

    private void OnCartaoNipcFileSelected(IBrowserFile? file)
    {
        selectedCartaoNipcFile = file;

        if (selectedCartaoNipcFile is not null)
        {
            IsCartaoNipcSelected = true;
        }
        else
        {
            IsCartaoNipcSelected = false;
        }
    }

    private async Task DownloadCartaoNipc(MouseEventArgs e)
    {
        if (CartaoNipc?.FicheiroId > 0)
        {
            await DownloadFile(CartaoNipc.FicheiroId);
        }
    }

    private async Task DownloadFile(long ficheiroId)
    {
        FileData fileData = await FicheiroApiService.DownloadFicheiro(ficheiroId);
        if (fileData is null) return;

        await FileManagementClientSide.DownloadFile(jSRuntime, fileData);
    }
}
