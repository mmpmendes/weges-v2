using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using weges_v2.ApiModel.Models;

using weges_v2.ApiService.Data;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstabelecimentoController(
    ISimpleRepository<Estabelecimento> estabelecimentoRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Estabelecimento> _estabelecimentoRepo = estabelecimentoRepo;
    private readonly IMapper _mapper = mapper;

    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<EstabelecimentoDTO>>(_estabelecimentoRepo.GetAll()));
    }
}
