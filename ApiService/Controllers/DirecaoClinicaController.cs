using ApiModel.Models;
using ApiService.Contracts.Repositories;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirecaoClinicaController(
        ISimpleRepository<DirecaoClinica> direcaoRepo,
        ITipologiaRepository tipologiaRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<DirecaoClinica> _direcaoRepo = direcaoRepo;
    private readonly ITipologiaRepository _tipologiaRepo = tipologiaRepo;
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
            if (!string.IsNullOrEmpty(direcaoClinicaModel.TipologiaNome))
            {
                var tipologia = await _tipologiaRepo.GetByNome(direcaoClinicaModel.TipologiaNome);
                var newDir = _mapper.Map<DirecaoClinica>(direcaoClinicaModel);
                newDir.Tipologia = tipologia;
                await _direcaoRepo.Create(newDir);
                return Results.Created();
            }
            else
            {
                await _direcaoRepo.Create(_mapper.Map<DirecaoClinica>(direcaoClinicaModel));
                return Results.Created();
            }
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
    [HttpPatch("{Id}")]
    public async Task<IResult> UpdateServico(long Id, [FromBody] DirecaoClinicaDTO direcaoClinicaModel)
    {
        if (direcaoClinicaModel == null)
            return Results.BadRequest("Direção clínica inválida.");

        // Ensure the record exists
        var existingEntity = await _direcaoRepo.GetById(Id);
        if (existingEntity == null)
            return Results.NotFound($"No record found with ID {Id}");

        try
        {
            // Perform the update
            var updatedEntity = _mapper.Map(direcaoClinicaModel, existingEntity);
            await _direcaoRepo.Update(Id, updatedEntity);

            return Results.Ok();
        }
        catch (Exception ex)
        {
            // Log the exception (optional)
            return Results.Problem($"An error occurred: {ex.Message}");
        }
    }
}
