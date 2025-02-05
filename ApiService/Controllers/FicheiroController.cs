using ApiModel.Models;

using ApiService.Data;
using ApiService.Services;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FicheiroController(
    ISimpleRepository<Ficheiro> ficheiroRepo
    , ISimpleRepository<CertificadoERS> certificadoErsRepo
    , IConfiguration config
    , IFileService fileService
    ) : ControllerBase
{
    private const string UPLOADPATH = "Paths:uploadpath";
    private readonly IFileService _fileService = fileService;
    private readonly IConfiguration _config = config;
    private readonly ISimpleRepository<Ficheiro> _ficheiroRepo = ficheiroRepo;
    private readonly ISimpleRepository<CertificadoERS> _certificadoErsRepo = certificadoErsRepo;

    private async Task<FileResult?> GetFile(long ficheiroId)
    {
        Ficheiro? Ficheiro = await _ficheiroRepo.GetById(ficheiroId);
        if (Ficheiro == null)
        {
            return null;
        }

        string certificadoPath = Path.Combine(_config[UPLOADPATH], Ficheiro.Localizacao!);

        if (!System.IO.File.Exists(certificadoPath))
        {
            return null;
        }
        var ficheiro = _fileService.GetFileAsByteArray(certificadoPath);
        var contentType = _fileService.GetContentType(certificadoPath);

        return new FileContentResult(ficheiro, contentType)
        {
            FileDownloadName = Ficheiro.Nome
        };
    }

    [HttpGet("DownloadFicheiro/{ficheiroId}")]
    public async Task<IResult> DownloadFicheiro(long ficheiroId)
    {
        var ficheiro = await GetFile(ficheiroId);

        if (ficheiro == null)
        {
            return Results.Ok();
        }

        return Results.Ok(ficheiro);

    }

    [HttpGet("DownloadCertificadoERS/{certificadoId}")]
    public async Task<IResult> DownloadCertificadoERS(long certificadoId)
    {
        var certificado = await _certificadoErsRepo.GetById(certificadoId);

        if (certificado == null || certificado.FicheiroId == null)
        {
            return Results.Ok();
        }

        return Results.Ok(await GetFile((long)certificado.FicheiroId));
    }
}
