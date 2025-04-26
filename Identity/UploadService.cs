namespace WebApp;

public class UploadService(IWebHostEnvironment webHostEnvironment)
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;


    public void UploadFile(string imageName, byte[] imageContent)
    {
        var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{imageName}";
        var fileStream = File.Create(path);
        fileStream.Write(imageContent, 0, imageContent.Length);
        fileStream.Close();
    }
}
