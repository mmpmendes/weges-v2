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
        var ficheiro = await _ficheiroRepo.GetById(ficheiroId);
        if (ficheiro == null)
        {
            return null;
        }

        string filePath = Path.Combine(_config[UPLOADPATH], ficheiro.Localizacao!);

        if (!System.IO.File.Exists(filePath))
        {
            return null;
        }

        var fileBytes = _fileService.GetFileAsByteArray(filePath);
        var contentType = _fileService.GetContentType(filePath);

        return File(fileBytes, contentType, ficheiro.Nome);
    }

    [HttpGet("DownloadFicheiro/{ficheiroId}")]
    public async Task<IActionResult> DownloadFicheiro(long ficheiroId)
    {
        var fileResult = await GetFile(ficheiroId);

        if (fileResult == null)
        {
            return NotFound("File not found.");
        }

        return fileResult;
    }

    [HttpGet("DownloadCertificadoERS/{certificadoId}")]
    public async Task<IActionResult> DownloadCertificadoERS(long certificadoId)
    {
        var certificado = await _certificadoErsRepo.GetById(certificadoId);

        if (certificado == null || certificado.FicheiroId == null)
        {
            return NotFound("Certificado not found or does not have an associated file.");
        }

        var fileResult = await GetFile((long)certificado.FicheiroId);
        if (fileResult == null)
        {
            return NotFound("Associated file not found.");
        }

        return fileResult;
    }
}
