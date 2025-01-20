using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using Services;

using SharedKernel.DTO;

using System.Net.Http.Headers;

namespace Identity.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoCertificadosLicencas
{
    [Parameter]
    public long Id { get; set; }
    [Inject]
    private EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    public IBrowserFile? selectedCertificadoFile = default!;
    public IBrowserFile? selectedLicencaFile = default!;
    private bool IsFileSelected { get; set; }
    private readonly long maxFileSize = 1024 * 1024 * 5;
    private CertificadoErsDTO? CertificadoErs { get; set; }
    private LicencaErsDTO? LicencaErs { get; set; }

    protected override Task OnInitializedAsync()
    {
        EstabelecimentoApiService.GetEstabelecimentoCertificadoErsAsync(Id).ContinueWith(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                CertificadoErs = task.Result;
            }
        });

        EstabelecimentoApiService.GetEstabelecimentoLicencaErsAsync(Id).ContinueWith(task =>
        {
            if (task.IsCompletedSuccessfully)
            {
                LicencaErs = task.Result;
            }
        });

        return base.OnInitializedAsync();
    }



    #region Certificado
    private async Task UploadCertificado()
    {
        if (selectedCertificadoFile is null) return;

        using var formData = new MultipartFormDataContent();

        var stream = new StreamContent(selectedCertificadoFile.OpenReadStream(maxFileSize));
        stream.Headers.ContentType = new MediaTypeHeaderValue(selectedCertificadoFile.ContentType);

        formData.Add(stream, "file", selectedCertificadoFile.Name);

        await EstabelecimentoApiService.UploadCertificadoAsync(formData);

        IsFileSelected = false;
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
}
