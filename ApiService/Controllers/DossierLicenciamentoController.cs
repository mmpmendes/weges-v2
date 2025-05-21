using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DossierLicenciamentoController(
        //ISimpleRepository<Estabelecimento> estabelecimentoRepo
        //, IMapper mapper
        ) : ControllerBase
{
    //private readonly ISimpleRepository<Estabelecimento> estabelecimentoRepo = estabelecimentoRepo;
    //private readonly IMapper mapper = mapper;

    //[HttpGet("{EstabelecimentoId}/GetCartaoNIPC")]
    //public async Task<IResult> GetCartaoNIPC(long EstabelecimentoId)
    //{
    //    var estabelecimento = await estabelecimentoRepo.GetByIdAsync(EstabelecimentoId);

    //    if (estabelecimento == null)
    //        return Results.NotFound();

    //    return Results.Ok(estabelecimento.CartaoNipc);
    //}

    //[HttpPost]
    //public async Task<IResult> SaveCartaoNipc([FromBody] AnexoDTO CartaoNipc)
    //{
    //    var estabelecimento = await estabelecimentoRepo.GetByIdAsync(CartaoNipc.EstabelecimentoId);

    //    if (estabelecimento == null)
    //    {
    //        return Results.NotFound();
    //    }

    //    var cartao = mapper.Map<Anexo>(CartaoNipc);

    //    estabelecimento.CartaoNipc = cartao;

    //    await estabelecimentoRepo.UpdateAsync(estabelecimento);

    //    return Results.Ok();
    //}

    //[HttpGet("{EstabelecimentoId}/GetAlvara")]
    //public async Task<IResult> GetAlvara(long EstabelecimentoId)
    //{
    //    var estabelecimento = await estabelecimentoRepo.GetByIdAsync(EstabelecimentoId);

    //    if (estabelecimento == null)
    //        return Results.NotFound();

    //    return Results.Ok(estabelecimento.Alvara);
    //}

    //[HttpGet("{EstabelecimentoId}/GetMedidaANPC")]
    //public async Task<IResult> GetMedidaANPC(long EstabelecimentoId)
    //{
    //    var estabelecimento = await estabelecimentoRepo.GetByIdAsync(EstabelecimentoId);

    //    if (estabelecimento == null)
    //        return Results.NotFound();

    //    return Results.Ok(estabelecimento.MedidaAnpc);
    //}

    //[HttpGet("{EstabelecimentoId}/GetParecerANPC")]
    //public async Task<IResult> GetParecerANPC(long EstabelecimentoId)
    //{
    //    var estabelecimento = await estabelecimentoRepo.GetByIdAsync(EstabelecimentoId);

    //    if (estabelecimento == null)
    //        return Results.NotFound();

    //    return Results.Ok(estabelecimento.ParecerAnpc);
    //}
}
