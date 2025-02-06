using ApiModel.Models;

using ApiService.Data;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DossierLicenciamento(
        ISimpleRepository<Estabelecimento> estabelecimentoRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Estabelecimento> estabelecimentoRepo = estabelecimentoRepo;
    private readonly IMapper mapper = mapper;

    [HttpGet("{EstabelecimentoId}/GetCartaoNIPC")]
    public async Task<IResult> GetCartaoNIPC(long EstabelecimentoId)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(EstabelecimentoId);

        if (estabelecimento == null)
            return Results.NotFound();

        return Results.Ok(estabelecimento.CartaoNIPC);
    }

    [HttpGet("{EstabelecimentoId}/GetAlvara")]
    public async Task<IResult> GetAlvara(long EstabelecimentoId)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(EstabelecimentoId);

        if (estabelecimento == null)
            return Results.NotFound();

        return Results.Ok(estabelecimento.Alvara);
    }

    [HttpGet("{EstabelecimentoId}/GetMedidaANPC")]
    public async Task<IResult> GetMedidaANPC(long EstabelecimentoId)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(EstabelecimentoId);

        if (estabelecimento == null)
            return Results.NotFound();

        return Results.Ok(estabelecimento.MedidaANPC);
    }

    [HttpGet("{EstabelecimentoId}/GetParecerANPC")]
    public async Task<IResult> GetParecerANPC(long EstabelecimentoId)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(EstabelecimentoId);

        if (estabelecimento == null)
            return Results.NotFound();

        return Results.Ok(estabelecimento.ParecerANPC);
    }
}
