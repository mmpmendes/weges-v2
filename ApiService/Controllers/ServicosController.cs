using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using ApiModel.Models;

using ApiService.Data;
using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServicosController(
    ISimpleRepository<Servico> servicoRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Servico> _servicoRepo = servicoRepo;
    private readonly IMapper _mapper = mapper;
    /// <summary>
    /// Retorna a lista de todos os servicos
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<ServicoDTO>>(_servicoRepo.GetAll()));
    }
    /// <summary>
    /// Retorna o servico com o <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var servico = await _servicoRepo.GetById(Id);
        if (servico == null) return Results.BadRequest("Servico não encontrado.");
        ServicoDTO toReturn = _mapper.Map<ServicoDTO>(servico);
        return Results.Ok(toReturn);
    }
    /// <summary>
    /// Cria uma entidade com base
    /// </summary>
    /// <param name="servicoModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateServico([FromBody] ServicoDTO servicoModel)
    {
        if (servicoModel == null) return Results.BadRequest("Servico inválido.");
        try
        {
            await _servicoRepo.Create(_mapper.Map<Servico>(servicoModel));
            return Results.Created();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
    /// <summary>
    /// Atualiza uma entidade com base no <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="servicoModel"></param>
    /// <returns></returns>
    [HttpPut("{Id}")]
    public async Task<IResult> UpdateServico(long Id, [FromBody] ServicoDTO servicoModel)
    {
        if (servicoModel == null) return Results.BadRequest("Servico inválido.");
        try
        {
            await _servicoRepo.Update(Id, _mapper.Map<Servico>(servicoModel));
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}
