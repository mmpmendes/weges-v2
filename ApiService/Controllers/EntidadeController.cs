using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using ApiModel.Models;
using SharedKernel.DTO;
using ApiService.Contracts.Repositories;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntidadeController(
        ISimpleRepository<Entidade> entidadeRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Entidade> _entidadeRepo = entidadeRepo;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Retorna a lista de todas as entidades
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<EntidadeDTO>>(_entidadeRepo.GetAll()));
    }

    /// <summary>
    /// Retorna a entidade com o <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var entidade = await _entidadeRepo.GetById(Id);
        if (entidade == null) return Results.BadRequest("Entidade não encontrada.");
        EntidadeDTO toReturn = _mapper.Map<EntidadeDTO>(entidade);

        return Results.Ok(toReturn);
    }

    /// <summary>
    /// Cria uma entidade com base
    /// </summary>
    /// <param name="entidadeModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateEntidade([FromBody] EntidadeDTO entidadeModel)
    {
        if (entidadeModel == null) return Results.BadRequest("Entidade inválida.");

        try
        {
            await _entidadeRepo.Create(_mapper.Map<Entidade>(entidadeModel));
            return Results.Created();
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a gravar entidade.");
        }
    }

    [HttpPatch]
    public async Task<IResult> AtualizaEntidade([FromBody] EntidadeDTO entidadeModel)
    {
        if (entidadeModel == null) return Results.BadRequest("Entidade inválida.");

        var existingEntidade = await _entidadeRepo.GetById(entidadeModel.Id);

        _mapper.Map(entidadeModel, existingEntidade);

        try
        {
            await _entidadeRepo.Update(entidadeModel.Id, existingEntidade);
            return Results.Created();
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a atualizar entidade.");
        }
    }
}

