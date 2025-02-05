namespace Services.Models;

public class FileData
{
    public byte[] FileBytes { get; }
    public string FileName { get; }
    public string ContentType { get; }

    public FileData(byte[] fileBytes, string fileName, string contentType)
    {
        FileBytes = fileBytes;
        FileName = fileName;
        ContentType = contentType;
    }
}
