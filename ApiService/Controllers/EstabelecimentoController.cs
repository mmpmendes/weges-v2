using ApiModel.Models;

using ApiService.Data;
using ApiService.Services;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstabelecimentoController(
        ISimpleRepository<Estabelecimento> estabelecimentoRepo,
        ISimpleRepository<CertificadoERS> repoCertificadoRepo,
        ISimpleRepository<LicencaERS> repoLicencaRepo
        , IConfiguration config
        , IFileService servFile
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Estabelecimento> _estabelecimentoRepo = estabelecimentoRepo;
    private readonly ISimpleRepository<CertificadoERS> _certificadoRepo = repoCertificadoRepo;
    private readonly ISimpleRepository<LicencaERS> _licencaRepo = repoLicencaRepo;
    private readonly IMapper _mapper = mapper;
    private const string UPLOADPATH = "Paths:uploadpath";
    private readonly IFileService _servFile = servFile;
    private readonly IConfiguration _config = config;

    /// <summary>
    /// Retorna a lista de todos os estabelecimentos
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<EstabelecimentoDTO>>(_estabelecimentoRepo.GetAll()));
    }

    /// <summary>
    /// Retorna o estabelecimetno com o <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var estabelecimento = await _estabelecimentoRepo.GetById(Id);
        if (estabelecimento == null) return Results.BadRequest("Estabelecimento não encontrado.");
        EstabelecimentoDTO toReturn = _mapper.Map<EstabelecimentoDTO>(estabelecimento);

        return Results.Ok(toReturn);
    }

    /// <summary>
    /// Cria um estabelecimmento
    /// </summary>
    /// <param name="estabelecimentoModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateEstabelecimento([FromBody] EstabelecimentoDTO estabelecimentoModel)
    {
        if (estabelecimentoModel == null) return Results.BadRequest("Estabelecimento inválido.");

        try
        {
            await _estabelecimentoRepo.Create(_mapper.Map<Estabelecimento>(estabelecimentoModel));
            return Results.Created();
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a gravar Estabelecimento.");
        }
    }

    /// <summary>
    /// Atualiza um estabelecimento
    /// </summary>
    /// <param name="estabelecimentoModel"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IResult> AtualizaEstabelecimento([FromBody] EstabelecimentoDTO estabelecimentoModel)
    {
        if (estabelecimentoModel == null) return Results.BadRequest("Estabelecimento inválido.");

        var estabelecimentoExistente = await _estabelecimentoRepo.GetById(estabelecimentoModel.Id);

        _mapper.Map(estabelecimentoModel, estabelecimentoExistente);

        try
        {
            await _estabelecimentoRepo.Update(estabelecimentoModel.Id, estabelecimentoExistente);
            return Results.Created();
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a atualizar estabelecimento.");
        }
    }

    ///FICHEIROS

    ///// <summary>
    ///// Grava os dados do certificado
    ///// </summary>
    ///// <param name="estabelecimentoModel"></param>
    ///// <returns></returns>
    //[HttpPost("SaveCertificadoData")]
    //public async Task<IResult> SaveCertificadoData([FromBody] CertificadoErsDTO certificadoErsDTO)
    //{
    //    if (certificadoErsDTO == null)
    //    {
    //        return Results.BadRequest("Erro, dados inválidos");
    //    }

    //    try
    //    {
    //        if (certificadoErsDTO.Id > -1)
    //        {

    //            var existingCertificado = await _certificadoRepo.GetById(certificadoErsDTO.Id);

    //            if (existingCertificado == null)
    //            {
    //                return Results.NotFound();
    //            }

    //            _mapper.Map(certificadoErsDTO, existingCertificado);

    //            if (certificadoErsDTO.FicheiroId == -1)
    //            {
    //                existingCertificado.FicheiroId = -1;
    //                existingCertificado.NomeFicheiro = certificadoErsDTO.NomeFicheiro;
    //                existingCertificado.Localizacao = certificadoErsDTO.Localizacao;
    //            }

    //            await _certificadoRepo.Update(existingCertificado.Id, existingCertificado);
    //        }
    //        else
    //        {
    //            var mapped = _mapper.Map<CertificadoERS>(certificadoErsDTO);
    //            await _certificadoRepo.Create(mapped);
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        return Results.BadRequest("Certificado não criado");
    //    }


    //    return Results.Ok();
    //}

    //[HttpPost("SaveLicencaData")]
    //public async Task<IResult> SaveLicencaData(long estabelecimentoId, [FromBody] LicencaErsDTO licencaErsDTO)
    //{

    //    if (licencaErsDTO == null)
    //    {
    //        return Results.BadRequest("Erro, dados inválidos");
    //    }

    //    try
    //    {
    //        if (licencaErsDTO.Id > -1)
    //        {
    //            var existingLicenca = await _licencaRepo.GetById(licencaErsDTO.Id);

    //            if (existingLicenca == null)
    //            {
    //                return Results.NotFound();
    //            }

    //            _mapper.Map(licencaErsDTO, existingLicenca);

    //            if (licencaErsDTO.FicheiroId == -1)
    //            {
    //                existingLicenca.FicheiroId = -1;
    //                existingLicenca.NomeFicheiro = licencaErsDTO.NomeFicheiro;
    //                existingLicenca.Localizacao = licencaErsDTO.Localizacao;
    //            }

    //            await _licencaRepo.Update(licencaErsDTO.Id, existingLicenca);
    //        }
    //        else
    //        {
    //            await _licencaRepo.Create(_mapper.Map<LicencaERS>(licencaErsDTO));
    //        }
    //    }
    //    catch (Exception)
    //    {
    //        return Results.BadRequest("Licença não criado");
    //    }

    //    return Results.Ok();
    //}

    /// <summary>
    /// Faz o upload de um ficheiro para o sistema de ficheiros
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    [HttpPost("UploadCertificado")]
    public async Task<IResult> UploadCertificado([FromForm] IFormFile file)
    {

        string fileLocationAndName = await _servFile.SaveFileToFileSystem(file, "shift", _config[UPLOADPATH]);

        return Results.Ok(fileLocationAndName);
        //return Results.Ok();
    }

    ///// <summary>
    ///// Grava o ficheiro de licença
    ///// </summary>
    ///// <param name="file"></param>
    ///// <param name="folder"></param>
    ///// <returns></returns>
    //[HttpPost("UploadLicenca")]
    //public async Task<IResult> UploadLicenca(IFormFile file, [FromForm] string folder)
    //{
    //    string fileLocationAndName = await _servFile.SaveFileToFileSystem(file, folder, _config[UPLOADPATH]);

    //    return Results.Ok(fileLocationAndName);
    //}


    //[HttpGet("DownloadCertificadoByCertificadoId")]
    //public async Task<IActionResult> DownloadCertificado(long certificadoId)
    //{
    //    CertificadoERS? certificado = await _certificadoRepo.GetById(certificadoId);

    //    if (certificado == null)
    //    {
    //        return NotFound("Ficheiro não encontrado na base de dados.");
    //    }

    //    string certificadoPath = Path.Combine(_config[UPLOADPATH], certificado.Localizacao);

    //    if (!System.IO.File.Exists(certificadoPath))
    //    {
    //        return NotFound("Ficheiro não encontrado no sistema de ficheiros.");
    //    }

    //    var ficheiro = _servFile.GetFileAsByteArray(certificadoPath);

    //    return File(ficheiro, _servFile.GetContentType(certificadoPath), certificado.NomeFicheiro);
    //}

    //[HttpGet("DownloadLicencaByLicencaId")]
    //public async Task<IActionResult> DownloadLicenca(long licencaId)
    //{
    //    LicencaERS? licenca = await _licencaRepo.GetById(licencaId);

    //    if (licenca == null)
    //    {
    //        return NotFound("Ficheiro não encontrado na base de dados.");
    //    }

    //    string licencaPath = Path.Combine(_config[UPLOADPATH], licenca.Localizacao);

    //    if (!System.IO.File.Exists(licencaPath))
    //    {
    //        return NotFound("Ficheiro não encontrado no sistema de ficheiros.");
    //    }

    //    var ficheiro = _servFile.GetFileAsByteArray(licencaPath);

    //    return File(ficheiro, _servFile.GetContentType(licencaPath), licenca.NomeFicheiro);
    //}
}
