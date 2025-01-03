using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Web.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoCertificadosLicencas
{
    [Parameter]
    public long Id { get; set; }

    private IBrowserFile? SelectedFile;
    private bool IsFileSelected = false;
    private bool IsUploading = false;
    private int ProgressValue = 0;
    private string? UploadMessage;

    private async Task HandleFileSelected(ChangeEventArgs e)
    {
        if (e.Value is not null && e.Value is IBrowserFile file)
        {
            SelectedFile = file;
            IsFileSelected = true;
        }
    }

    private async Task UploadFile()
    {
        if (SelectedFile is null)
        {
            return;
        }

        IsUploading = true;

        try
        {
            using var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(SelectedFile.OpenReadStream());
            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(SelectedFile.ContentType);
            content.Add(fileContent, "file", SelectedFile.Name);

            //var response = await HttpClient.PostAsync("api/upload", content);
            //if (response.IsSuccessStatusCode)
            //{
            //    UploadMessage = "File uploaded successfully!";
            //}
            //else
            //{
            //    UploadMessage = "File upload failed!";
            //}
        }
        catch (Exception ex)
        {
            UploadMessage = $"An error occurred: {ex.Message}";
        }
        finally
        {
            IsUploading = false;
            IsFileSelected = false;
            ProgressValue = 0;
        }
    }
}
