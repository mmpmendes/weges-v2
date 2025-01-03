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
        ISimpleRepository<Estabelecimento> estabelecimentoRepo
        , IConfiguration config
        , IFileService servFile
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Estabelecimento> _estabelecimentoRepo = estabelecimentoRepo;
    private readonly IMapper _mapper = mapper;
    private const string UPLOADPATH = "paths:upload-path";
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
    /// Cria uma entidade com base
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

    [HttpPost("SaveCertificadoData")]
    public async Task<IResult> SaveCertificadoData([FromBody] EstabelecimentoDTO estabelecimentoModel)
    {

        return Results.Ok();
    }

    [HttpPost("UploadCertificado")]
    public async Task<IResult> UploadCertificado(IFormFile file, [FromForm] string folder)
    {
        string fileLocationAndName = await _servFile.SaveFileToFileSystem(file, folder, _config[UPLOADPATH]);

        return Results.Ok(fileLocationAndName);
    }
}
