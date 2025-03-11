using ApiModel.Models;

using ApiService.Contracts.Repositories;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DossierLicenciamentoController(
        ISimpleRepository<Estabelecimento> estabelecimentoRepo
        , ISimpleRepository<Anexo> anexoRepo
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Estabelecimento> estabelecimentoRepo = estabelecimentoRepo;
    private readonly ISimpleRepository<Anexo> anexoRepo = anexoRepo;
    private readonly IMapper mapper = mapper;

    [HttpGet("{EstabelecimentoId}/GetCartaoNIPC")]
    public async Task<IResult> GetCartaoNIPC(long EstabelecimentoId)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(EstabelecimentoId);

        if (estabelecimento == null)
            return Results.NotFound();

        return Results.Ok(estabelecimento.CartaoNipc);
    }

    [HttpPost]
    public async Task<IResult> SaveCartaoNipc([FromBody] AnexoDTO CartaoNipc)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(CartaoNipc.EstabelecimentoId);

        if (estabelecimento == null)
        {
            return Results.NotFound();
        }

        var cartao = mapper.Map<Anexo>(CartaoNipc);

        estabelecimento.CartaoNipc = cartao;

        await estabelecimentoRepo.Update(estabelecimento.Id, estabelecimento);

        return Results.Ok();
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

        return Results.Ok(estabelecimento.MedidaAnpc);
    }

    [HttpGet("{EstabelecimentoId}/GetParecerANPC")]
    public async Task<IResult> GetParecerANPC(long EstabelecimentoId)
    {
        var estabelecimento = await estabelecimentoRepo.GetById(EstabelecimentoId);

        if (estabelecimento == null)
            return Results.NotFound();

        return Results.Ok(estabelecimento.ParecerAnpc);
    }
}
