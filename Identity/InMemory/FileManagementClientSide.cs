using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

using Services.Models;

using System.Net.Http.Headers;

namespace Identity.InMemory;

public static class FileManagementClientSide
{
    private static readonly long maxFileSize = 1024 * 1024 * 5;
    public static StreamContent? SetupFileForUpload(IBrowserFile? file)
    {
        if (file == null) return null;
        var stream = new StreamContent(file.OpenReadStream(maxFileSize));
        stream.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
        return stream;
    }

    public static async Task DownloadFile(IJSRuntime jSRuntime, FileData fileData)
    {
        if (fileData != null && fileData.FileBytes.Length > 0)
        {
            var base64 = Convert.ToBase64String(fileData.FileBytes);
            var contentType = fileData.ContentType ?? "application/octet-stream";
            var jsFileName = fileData.FileName ?? "download";

            await jSRuntime.InvokeVoidAsync("blazorDownloadFile", base64, contentType, jsFileName);
        }
    }
}
