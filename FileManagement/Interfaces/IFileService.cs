using Microsoft.AspNetCore.Http;

namespace ApiService.Services;

public interface IFileService
{
    public Task<string> SaveFileToFileSystem(IFormFile file, string configFolder);
    public string GetContentType(string path);
    public byte[] GetFileAsByteArray(string path);
}
