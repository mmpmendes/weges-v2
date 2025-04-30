namespace WebApp;

public class UploadService(
    IWebHostEnvironment webHostEnvironment
    , IHttpContextAccessor httpContextAccessor)
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    /// <summary>
    /// Uploads a file to the specified folder.
    /// Just needs to be mapped to a correct folder in the web server.
    /// </summary>
    /// <param name="folderName"></param>
    /// <param name="imageName"></param>
    /// <param name="imageContent"></param>
    public string UploadFileToFolder(string folderName, string imageName, byte[] imageContent)
    {
        var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{folderName}\\{imageName}";
        var fileStream = File.Create(path);
        fileStream.Write(imageContent, 0, imageContent.Length);
        fileStream.Close();
        return path;
    }

    public string CalcularUrl(string folderName, string fileName)
    {
        var currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
        return $"https://{currentUrl}\\uploads\\{folderName}\\{fileName}";
    }
}
