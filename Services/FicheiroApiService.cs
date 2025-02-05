namespace Services;
public class FicheiroApiService(HttpClient httpClient)
{
    public async Task DownloadFicheiro(long ficheiroId, CancellationToken cancellationToken = default)
    {
        await httpClient.GetStreamAsync($"/api/Ficheiro/DownloadFicheiro/{ficheiroId}", cancellationToken);
    }

    public async Task DownloadCertificadoErs(long certificadoId, CancellationToken cancellationToken = default)
    {
        await httpClient.GetStreamAsync($"/Ficheiro/DownloadCertificadoErs/{certificadoId}", cancellationToken);
    }
}
