using ApiModel.Models;

using ApiService.Contracts.Repositories;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FicheiroController(
    ISimpleRepository<Ficheiro> ficheiroRepo
    , IMapper mapper
    ) : ControllerBase
{
    private readonly IMapper _mapper = mapper;
    private readonly ISimpleRepository<Ficheiro> _ficheiroRepo = ficheiroRepo;

    [HttpPost("CriarFicheiro")]
    public async Task<IResult> CriarFicheiro([FromBody] FicheiroDTO model)
    {
        var ficheiro = _mapper.Map<Ficheiro>(model);

        try
        {
            await _ficheiroRepo.Create(ficheiro);
            return Results.Ok(_mapper.Map<FicheiroDTO>(ficheiro));
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a gravar o ficheiro");
        }
    }

    //private async Task<FileResult?> GetFile(long ficheiroId)
    //{
    //    var ficheiro = await _ficheiroRepo.GetById(ficheiroId);
    //    if (ficheiro == null)
    //    {
    //        return null;
    //    }

    //    string filePath = Path.Combine(_config[UPLOADPATH], ficheiro.Localizacao!);

    //    if (!System.IO.File.Exists(filePath))
    //    {
    //        return null;
    //    }

    //    var fileBytes = _fileService.GetFileAsByteArray(filePath);
    //    var contentType = _fileService.GetContentType(filePath);

    //    return File(fileBytes, contentType, ficheiro.Nome);
    //}

    //private async Task<IResult> SaveFicheiro(string fileName, string fileLocationAndName)
    //{
    //    // second - save the file to the ficheiros table
    //    Ficheiro ficheiro = new Ficheiro()
    //    {
    //        Nome = fileName,
    //        Localizacao = fileLocationAndName
    //    };

    //    try
    //    {
    //        await _ficheiroRepo.Create(ficheiro);

    //        return Results.Ok(_mapper.Map<FicheiroDTO>(ficheiro));
    //    }
    //    catch (Exception)
    //    {
    //        return Results.InternalServerError("Erro a gravar o ficheiro");
    //    }
    //}

    //[HttpPost("UploadFicheiro")]
    //public async Task<IResult> UploadFicheiro(IFormFile file)
    //{
    //    // first - save the file to the file system
    //    string fileLocationAndName = await _fileService.SaveFileToFileSystem(file, _config[UPLOADPATH]);

    //    return await SaveFicheiro(file.Name, fileLocationAndName);
    //}


    //[HttpGet("DownloadFicheiro/{ficheiroId}")]
    //public async Task<IActionResult> DownloadFicheiro(long ficheiroId)
    //{
    //    var fileResult = await GetFile(ficheiroId);

    //    if (fileResult == null)
    //    {
    //        return NotFound("File not found.");
    //    }

    //    return fileResult;
    //}

    //[HttpGet("DownloadCertificadoERS/{certificadoId}")]
    //public async Task<IActionResult> DownloadCertificadoERS(long certificadoId)
    //{
    //    var certificado = await _certificadoErsRepo.GetById(certificadoId);

    //    if (certificado == null || certificado.FicheiroId == null)
    //    {
    //        return NotFound("Certificado not found or does not have an associated file.");
    //    }

    //    var fileResult = await GetFile((long)certificado.FicheiroId);
    //    if (fileResult == null)
    //    {
    //        return NotFound("Associated file not found.");
    //    }

    //    return fileResult;
    //}


}