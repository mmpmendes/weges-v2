using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using weges_v2.ApiModel.Models;
using weges_v2.ApiService.Data;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirecaoClinicaController(
        ISimpleRepository<DirecaoClinica> direcaoRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<DirecaoClinica> _direcaoRepo = direcaoRepo;
    private readonly IMapper _mapper = mapper;

    /// <summary>
    /// Retorna a lista de todas as entidades
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<DirecaoClinicaDTO>>(_direcaoRepo.GetAll()));
    }

    /// <summary>
    /// Retorna a entidade com o <param name="Id"></param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var direcao = await _direcaoRepo.GetById(Id);
        if (direcao == null) return Results.BadRequest("Direção Clínica não encontrada.");
        DirecaoClinicaDTO toReturn = _mapper.Map<DirecaoClinicaDTO>(direcao);

        return Results.Ok(toReturn);
    }
    /// <summary>
    /// Cria uma entidade com base
    /// </summary>
    /// <param name="direcaoClinicaModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateServico([FromBody] DirecaoClinicaDTO direcaoClinicaModel)
    {
        if (direcaoClinicaModel == null) return Results.BadRequest("Direção clínica inválida.");
        try
        {
            await _direcaoRepo.Create(_mapper.Map<DirecaoClinica>(direcaoClinicaModel));
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
    /// <param name="direcaoClinicaModel"></param>
    /// <returns></returns>
    [HttpPut("{Id}")]
    public async Task<IResult> UpdateServico(long Id, [FromBody] DirecaoClinicaDTO direcaoClinicaModel)
    {
        if (direcaoClinicaModel == null) return Results.BadRequest("Direção clínica inválida.");
        try
        {
            await _direcaoRepo.Update(Id, _mapper.Map<DirecaoClinica>(direcaoClinicaModel));
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}
