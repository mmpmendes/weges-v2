using ApiService.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace FileManagement.Services;

public class FileService : IFileService
{
    public byte[] GetFileAsByteArray(string path) => ConvertFileToByteArray(path);

    private byte[] ConvertFileToByteArray(string path)
    {
        return File.ReadAllBytes(path);
    }

    public string GetContentType(string path)
    {
        var provider = new FileExtensionContentTypeProvider();
        string contentType;

        if (!provider.TryGetContentType(path, out contentType))
        {
            contentType = "application/octet-stream";
        }

        return contentType;
    }

    public async Task<string> SaveFileToFileSystem(IFormFile file, string configFolder)
    {
        if (file == null || file.Length == 0)
            return "No file uploaded";

        // Get the original file extension
        var fileExtension = Path.GetExtension(file.FileName);

        // Generate a new file name using a GUID, keeping the original extension
        var newFileName = $"{Guid.NewGuid()}{fileExtension}";

        // WANT TO CHECK IF SETFOLDER PATH EXISTS IF NOT CREATE IT
        // Check if the folder path exists, and if not, create it
        if (!Directory.Exists(configFolder))
        {
            Directory.CreateDirectory(configFolder);
        }

        string path = Path.Combine(configFolder, newFileName);

        // Save the file to the specified path
        using var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);

        // Return the new file name
        return newFileName;
    }
}