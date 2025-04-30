using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace WebApp.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoCertificadosLicencas
{
    [Parameter] public long Id { get; set; }
    [Inject] private EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] private FicheiroApiService FicheiroApiService { get; set; } = default!;
    [Inject] private UploadService UploadService { get; set; } = default!;

    public IBrowserFile? selectedCertificadoFile = default!;
    public IBrowserFile? selectedLicencaFile = default!;
    private bool IsCertificadoFileSelected { get; set; }
    private bool IsLicencaFileSelected { get; set; }

    private bool _editModeCertificado { get; set; } = false;
    private bool _editModeLicenca { get; set; } = false;

    private CertificadoErsDTO? CertificadoErs { get; set; }
    private LicencaErsDTO? LicencaErs { get; set; }

    private static List<string> periodosCertificados = ["Anual", "Bianual", "Semestral", "Trimestral", "Mensal"];

    protected override async Task OnInitializedAsync()
    {
        CertificadoErs = await EstabelecimentoApiService.GetEstabelecimentoCertificadoErsAsync(Id);

        LicencaErs = await EstabelecimentoApiService.GetEstabelecimentoLicencaErsAsync(Id);

        await base.OnInitializedAsync();
    }

    /// <summary>
    /// Uploads the selected file to the server and returns the file name.
    /// </summary>
    /// <returns></returns>
    private async Task<FicheiroDTO?> UploadFicheiro(string folder, IBrowserFile browserFile)
    {
        if (browserFile is not null)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(browserFile.Name);
            var file = browserFile;
            Stream stream = file.OpenReadStream();
            MemoryStream ms = new();
            await stream.CopyToAsync(ms);
            stream.Close();

            var path = UploadService.UploadFileToFolder(folder, fileName, ms.ToArray());
            return new FicheiroDTO()
            {
                Nome = fileName,
                NomeOriginal = file.Name,
                Tipo = file.ContentType,
                Url = path
            };
        }
        return null;
    }

    #region Certificado

    /// <summary>
    /// Uploads the selected file to the server and creates or updates the CertificadoErs.
    /// </summary>
    /// <returns></returns>
    private async Task UploadCertificado()
    {
        if (selectedCertificadoFile is not null)
        {
            var ficheiroUploaded = await UploadFicheiro("Certificados", selectedCertificadoFile);

            if (ficheiroUploaded is null) return;

            var ficheiroCriado = await FicheiroApiService.CriarFicheiro(new FicheiroDTO
            {
                NomeOriginal = ficheiroUploaded.NomeOriginal,
                Nome = ficheiroUploaded.Nome,
                Tipo = selectedCertificadoFile.ContentType,
                Url = ficheiroUploaded.Url
            });

            IsCertificadoFileSelected = false;

            if (ficheiroCriado is not null)
            {
                CertificadoErs!.FicheiroId = ficheiroCriado.Id;
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
        SetEditModeCertificado();
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
        if (selectedLicencaFile is not null)
        {
            var ficheiroUploaded = await UploadFicheiro("licencas", selectedLicencaFile);

            if (ficheiroUploaded is null) return;

            var ficheiroCriado = await FicheiroApiService.CriarFicheiro(new FicheiroDTO
            {
                NomeOriginal = ficheiroUploaded.NomeOriginal,
                Nome = ficheiroUploaded.Nome,
                Tipo = selectedLicencaFile.ContentType,
                Url = ficheiroUploaded.Url
            });

            IsLicencaFileSelected = false;

            if (ficheiroCriado is not null)
            {
                LicencaErs!.FicheiroId = ficheiroCriado.Id;
                LicencaErs!.EstabelecimentoId = Id;
            }
        }

        if (LicencaErs!.Id <= 0)
        {
            await EstabelecimentoApiService.CreateLicencaErsAsync(Id, LicencaErs);
        }
        else
        {
            await EstabelecimentoApiService.UpdateLicencaDataAsync(Id, LicencaErs);
        }
        SetEditModeLicenca();
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

    private string DownloadCertificadoErs()
    {
        if (CertificadoErs?.FicheiroId > 0)
        {
            return DownloadFile("certificados", CertificadoErs.Ficheiro.Nome);
        }
        return string.Empty;
    }
    private string DownloadLicencaErs()
    {
        if (LicencaErs?.FicheiroId > 0)
        {
            return DownloadFile("licencas", LicencaErs.Ficheiro.Nome);
        }
        return string.Empty;
    }

    private string DownloadFile(string folderName, string fileName)
    {
        return UploadService.CalcularUrl(folderName, fileName);
    }
    private void SetEditModeCertificado(MouseEventArgs? args = null)
    {
        _editModeCertificado = !_editModeCertificado;
    }
    private void SetEditModeLicenca(MouseEventArgs? args = null)
    {
        _editModeLicenca = !_editModeLicenca;
    }

}
