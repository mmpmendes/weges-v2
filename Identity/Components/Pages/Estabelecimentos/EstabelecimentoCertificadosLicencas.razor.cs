using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using Services;

using SharedKernel.DTO;

using System.Net.Http.Headers;

using static Services.FicheiroApiService;

namespace Identity.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoCertificadosLicencas
{
    [Parameter]
    public long Id { get; set; }
    [Inject]
    private EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject]
    private FicheiroApiService FicheiroApiService { get; set; } = default!;
    [Inject]
    private IJSRuntime jSRuntime { get; set; }

    public IBrowserFile? selectedCertificadoFile = default!;
    public IBrowserFile? selectedLicencaFile = default!;
    private bool IsFileSelected { get; set; }
    private readonly long maxFileSize = 1024 * 1024 * 5;
    private CertificadoErsDTO? CertificadoErs { get; set; }
    private LicencaErsDTO? LicencaErs { get; set; }

    protected override async Task OnInitializedAsync()
    {
        CertificadoErs = await EstabelecimentoApiService.GetEstabelecimentoCertificadoErsAsync(Id);

        LicencaErs = await EstabelecimentoApiService.GetEstabelecimentoLicencaErsAsync(Id);

        await base.OnInitializedAsync();
    }



    #region Certificado
    private async Task UploadCertificado()
    {
        if (selectedCertificadoFile is null) return;

        using var formData = new MultipartFormDataContent();

        var stream = new StreamContent(selectedCertificadoFile.OpenReadStream(maxFileSize));
        stream.Headers.ContentType = new MediaTypeHeaderValue(selectedCertificadoFile.ContentType);

        formData.Add(stream, "file", selectedCertificadoFile.Name);

        FicheiroDTO? ficheiro = await EstabelecimentoApiService.UploadCertificadoFileAsync(formData);

        IsFileSelected = false;

        if (ficheiro is not null)
        {
            CertificadoErs!.FicheiroId = ficheiro.Id;
            CertificadoErs!.EstabelecimentoId = Id;
        }
        if (CertificadoErs!.Id <= 0)
        {
            await EstabelecimentoApiService.CreateCertificadoErsAsync(Id, CertificadoErs);
        }
        else
        {
            await EstabelecimentoApiService.UpdateCertificadoDataAsync(Id, CertificadoErs);
        }
    }

    private void OnCertificadoFileSelected(IBrowserFile? file)
    {
        selectedCertificadoFile = file;

        if (selectedCertificadoFile is not null)
        {
            IsFileSelected = true;
        }
        else
        {
            IsFileSelected = false;
        }
    }
    #endregion

    #region Licenca
    private async Task UploadLicenca()
    {
        if (selectedLicencaFile is null) return;

        using var formData = new MultipartFormDataContent();

        var stream = new StreamContent(selectedLicencaFile.OpenReadStream(maxFileSize));
        stream.Headers.ContentType = new MediaTypeHeaderValue(selectedLicencaFile.ContentType);

        formData.Add(stream, "file", selectedLicencaFile.Name);

        await EstabelecimentoApiService.UploadLicencaAsync(formData);

        IsFileSelected = false;
    }

    private void OnLicencaFileSelected(IBrowserFile? file)
    {
        selectedLicencaFile = file;

        if (selectedLicencaFile is not null)
        {
            IsFileSelected = true;
        }
        else
        {
            IsFileSelected = false;
        }
    }

    #endregion

    private async Task DownloadFicheiro(MouseEventArgs e)
    {
        if (CertificadoErs?.FicheiroId > 0)
        {
            FileData fileData = await FicheiroApiService.DownloadFicheiro(CertificadoErs.FicheiroId);
            if (fileData != null && fileData.FileBytes.Length > 0)
            {
                var base64 = Convert.ToBase64String(fileData.FileBytes);
                var contentType = fileData.ContentType ?? "application/octet-stream";
                var jsFileName = fileData.FileName ?? "download";

                await jSRuntime.InvokeVoidAsync("blazorDownloadFile", base64, contentType, jsFileName);
            }
        }
    }
}
