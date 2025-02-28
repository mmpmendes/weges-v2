using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using Services;
using Services.Models;

using SharedKernel.DTO;

using WebApp.InMemory;

namespace WebApp.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoCertificadosLicencas
{
    [Parameter] public long Id { get; set; }
    [Inject] private EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] private FicheiroApiService FicheiroApiService { get; set; } = default!;
    [Inject] private IJSRuntime jSRuntime { get; set; } = default!;

    public IBrowserFile? selectedCertificadoFile = default!;
    public IBrowserFile? selectedLicencaFile = default!;
    private bool IsCertificadoFileSelected { get; set; }
    private bool IsLicencaFileSelected { get; set; }

    private bool _editModeCertificado { get; set; } = false;
    private bool _editModeLicenca { get; set; } = false;

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
        if (selectedCertificadoFile is not null)
        {

            using var formData = new MultipartFormDataContent();

            var stream = FileManagementClientSide.SetupFileForUpload(selectedCertificadoFile);

            if (stream is null) return;

            formData.Add(stream, "file", selectedCertificadoFile.Name);

            FicheiroDTO? ficheiro = await EstabelecimentoApiService.UploadCertificadoFileAsync(formData);

            IsCertificadoFileSelected = false;

            if (ficheiro is not null)
            {
                CertificadoErs!.FicheiroId = ficheiro.Id;
                CertificadoErs!.EstabelecimentoId = Id;
            }
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
            IsCertificadoFileSelected = true;
        }
        else
        {
            IsCertificadoFileSelected = false;
        }
    }
    #endregion

    #region Licenca
    private async Task UploadLicenca()
    {
        // TODO: Output mensagem de erro tentar de novo
        if (selectedLicencaFile is null) return;

        using var formData = new MultipartFormDataContent();

        var stream = FileManagementClientSide.SetupFileForUpload(selectedLicencaFile);

        // TODO: Output mensagem de erro tentar de novo
        if (stream is null) return;

        formData.Add(stream, "file", selectedLicencaFile.Name);

        FicheiroDTO? ficheiro = await EstabelecimentoApiService.UploadLicencaFileAsync(formData);

        IsLicencaFileSelected = false;

        if (ficheiro is not null)
        {
            LicencaErs!.FicheiroId = ficheiro.Id;
            LicencaErs!.EstabelecimentoId = Id;
        }
        if (LicencaErs!.Id <= 0)
        {
            await EstabelecimentoApiService.CreateLicencaErsAsync(Id, LicencaErs);
        }
        else
        {
            await EstabelecimentoApiService.UpdateLicencaDataAsync(Id, LicencaErs);
        }
    }

    private void OnLicencaFileSelected(IBrowserFile? file)
    {
        selectedLicencaFile = file;

        if (selectedLicencaFile is not null)
        {
            IsLicencaFileSelected = true;
        }
        else
        {
            IsLicencaFileSelected = false;
        }
    }

    #endregion

    private async Task DownloadCertificadoErs(MouseEventArgs e)
    {
        if (CertificadoErs?.FicheiroId > 0)
        {
            await DownloadFile(CertificadoErs.FicheiroId);
        }
    }
    private async Task DownloadLicencaErs(MouseEventArgs e)
    {
        if (LicencaErs?.FicheiroId > 0)
        {
            await DownloadFile(LicencaErs.FicheiroId);
        }
    }

    private async Task DownloadFile(long ficheiroId)
    {
        FileData fileData = await FicheiroApiService.DownloadFicheiro(ficheiroId);
        if (fileData is null) return;

        await FileManagementClientSide.DownloadFile(jSRuntime, fileData);
    }
    private void SetEditModeCertificado(MouseEventArgs args)
    {
        _editModeCertificado = !_editModeCertificado;
    }
    private void SetEditModeLicenca(MouseEventArgs args)
    {
        _editModeLicenca = !_editModeLicenca;
    }

}
