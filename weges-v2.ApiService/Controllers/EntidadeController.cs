using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using weges_v2.ApiModel.Models;
using weges_v2.ApiService.Data;
using weges_v2.ApiService.DTO;

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

    [HttpGet("id")]
    public async Task<IResult> Get(long Id)
    {
        var entidade = await _entidadeRepo.GetById(Id);
        if (entidade == null) return Results.BadRequest("Entidade não encontrada");
        EntidadeDTO toReturn = _mapper.Map<EntidadeDTO>(entidade);
        //if (toReturn != null)
        //{
        //    if (toReturn.CodCaeId != null)
        //    {
        //        toReturn.CodCae = _mapper.Map<CodCaeDTO>(await _codCaeRepo.GetByIdString(toReturn.CodCaeId));
        //    }

        //    toReturn.CaesSecundarios = _mapper.Map<IEnumerable<CodCaeDTO>>(await _codCaeRepo.GetCaesSecundariosByEntidadeId(Id));
        //}
        return Results.Ok(toReturn);
    }
}

