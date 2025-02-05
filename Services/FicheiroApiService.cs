namespace Services;
public class FicheiroApiService(HttpClient httpClient)
{
    public async Task<FileData> DownloadFicheiro(long ficheiroId, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/api/Ficheiro/DownloadFicheiro/{ficheiroId}", cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var fileBytes = await response.Content.ReadAsByteArrayAsync();
            var contentType = response.Content.Headers.ContentType?.ToString();
            var fileName = response.Content.Headers.ContentDisposition?.FileName?.Trim('"') ?? "ficheiro.pdf";

            return new FileData(fileBytes, fileName, contentType);
        }

        return null;
    }

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
}
