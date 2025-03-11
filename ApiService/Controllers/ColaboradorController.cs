using ApiModel.Models;

using ApiService.Contracts.Repositories;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColaboradorController(
        ISimpleRepository<Colaborador> colaboradorRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Colaborador> _colaboradorRepo = colaboradorRepo;
    private readonly IMapper _mapper = mapper;
    /// <summary>
    /// Retorna a lista de todos os colaboradores
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<ColaboradorDTO>>(_colaboradorRepo.GetAll()));
    }
    /// <summary>
    /// Retorna o colaborador com o <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var colaborador = await _colaboradorRepo.GetById(Id);
        if (colaborador == null) return Results.BadRequest("Colaborador não encontrado.");
        ColaboradorDTO toReturn = _mapper.Map<ColaboradorDTO>(colaborador);
        return Results.Ok(toReturn);
    }
    /// <summary>
    /// Cria um colaborador com base
    /// </summary>
    /// <param name="colaboradorModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateColaborador([FromBody] ColaboradorDTO colaboradorModel)
    {
        if (colaboradorModel == null) return Results.BadRequest("Colaborador inválido.");
        try
        {
            await _colaboradorRepo.Create(_mapper.Map<Colaborador>(colaboradorModel));
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Atualiza um colaborador com base
    /// </summary>
    /// <param name="colaboradorModel"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IResult> UpdateColaborador([FromBody] ColaboradorDTO colaboradorModel)
    {
        if (colaboradorModel == null) return Results.BadRequest("Colaborador inválido.");
        try
        {
            await _colaboradorRepo.Update(colaboradorModel.Id, _mapper.Map<Colaborador>(colaboradorModel));
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}
