using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using weges_v2.ApiModel.Models;
using weges_v2.ApiService.Data;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EntidadeController(
        ISimpleRepository<Entidade> entidadeRepo
        //, ICodCaeRepository codCaeRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Entidade> _entidadeRepo = entidadeRepo;
    //private readonly ICodCaeRepository _codCaeRepo = codCaeRepo;
    private readonly IMapper _mapper = mapper;

    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<EntidadeDTO>>(_entidadeRepo.GetAll()));
    }

    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var entidade = await _entidadeRepo.GetById(Id);
        if (entidade == null) return Results.BadRequest("Entidade não encontrada");
        EntidadeDTO toReturn = _mapper.Map<EntidadeDTO>(entidade);

        return Results.Ok(toReturn);
    }
}

