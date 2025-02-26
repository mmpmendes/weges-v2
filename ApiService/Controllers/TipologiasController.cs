using ApiModel.Models;

using ApiService.Data;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipologiasController(
        ISimpleRepository<Tipologia> tipologiaRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Tipologia> _tipologiaRepo = tipologiaRepo;
    private readonly IMapper _mapper = mapper;
    /// <summary>
    /// Retorna a lista de todas as tipologias
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<TipologiaDto>>(_tipologiaRepo.GetAll()));
    }
    /// <summary>
    /// Retorna a tipologia com o <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var tipologia = await _tipologiaRepo.GetById(Id);
        if (tipologia == null) return Results.BadRequest("Tipologia não encontrada.");
        TipologiaDto toReturn = _mapper.Map<TipologiaDto>(tipologia);
        return Results.Ok(toReturn);
    }
    /// <summary>
    /// Cria uma tipologia com base
    /// </summary>
    /// <param name="tipologiaModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateTipologia([FromBody] TipologiaDto tipologiaModel)
    {
        if (tipologiaModel == null) return Results.BadRequest("Tipologia inválida.");
        try
        {
            await _tipologiaRepo.Create(_mapper.Map<Tipologia>(tipologiaModel));
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}
