using ApiModel.Models;

using ApiService.Data;
using ApiService.Services;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SharedKernel.DTO;

namespace ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EstabelecimentoController(
        ISimpleRepository<Estabelecimento> estabelecimentoRepo,
        ISimpleRepository<CertificadoERS> certificadoRepo,
        ISimpleRepository<LicencaERS> licencaRepo,
        ISimpleRepository<Servico> servicoRepo,
        ISimpleRepository<DirecaoClinica> direcaoClinicaRepo,
        ISimpleRepository<Colaborador> colaboradorRepo,
        ISimpleRepository<Ficheiro> ficheiroRepo
        , IConfiguration config
        , IFileService fileService
        , IMapper mapper
        ) : ControllerBase
{
    private readonly ISimpleRepository<Estabelecimento> _estabelecimentoRepo = estabelecimentoRepo;
    private readonly ISimpleRepository<CertificadoERS> _certificadoRepo = certificadoRepo;
    private readonly ISimpleRepository<LicencaERS> _licencaRepo = licencaRepo;
    private readonly ISimpleRepository<Servico> _servicoRepo = servicoRepo;
    private readonly ISimpleRepository<DirecaoClinica> _direcaoClinicaRepo = direcaoClinicaRepo;
    private readonly ISimpleRepository<Colaborador> _colaboradorRepo = colaboradorRepo;
    private readonly ISimpleRepository<Ficheiro> _ficheiroRepo = ficheiroRepo;
    private readonly IMapper _mapper = mapper;
    private const string UPLOADPATH = "Paths:uploadpath";
    private readonly IFileService _fileService = fileService;
    private readonly IConfiguration _config = config;

    /// <summary>
    /// Retorna a lista de todos os estabelecimentos
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public IResult Get()
    {
        return Results.Ok(_mapper.Map<IEnumerable<EstabelecimentoDTO>>(_estabelecimentoRepo.GetAll()));
    }

    /// <summary>
    /// Retorna a lista de todos os estabelecimentos filtrados
    /// </summary>
    /// <returns></returns>
    [HttpGet("Filtrados")]
    public IResult GetEstabelecimentosFiltrados(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? sortString = null,
        [FromQuery] string? sortDirection = null,
        [FromQuery] Dictionary<string, string>? filters = null)
    {


        // Fetch all establishments
        var query = _estabelecimentoRepo.GetAll().AsQueryable();

        // Apply filters
        if (filters is not null)
        {
            foreach (var filter in filters)
            {
                if (filter.Key.Equals("pageNumber") || filter.Key.Equals("pageSize") || filter.Key.Equals("sortString") || filter.Key.Equals("sortDirection"))
                    continue;

                var propertyName = filter.Key;
                var filterValue = filter.Value;

                // Use reflection to filter dynamically
                query = query.Where(e => EF.Property<string>(e, propertyName).Contains(filterValue));
            }
        }

        // Apply sorting
        if (!string.IsNullOrWhiteSpace(sortString))
        {
            var isDescending = sortDirection?.Equals("desc", StringComparison.OrdinalIgnoreCase) ?? false;
            query = isDescending
                ? query.OrderByDescending(e => EF.Property<object>(e, sortString))
                : query.OrderBy(e => EF.Property<object>(e, sortString));
        }

        // Total count before pagination
        var totalCount = query.Count();
        if (pageSize == 0)
        {
            pageSize = totalCount;
        }
        // Apply pagination
        var paginatedData = query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        // Map to DTOs
        var result = _mapper.Map<IEnumerable<EstabelecimentoDTO>>(paginatedData);

        // Return paginated result
        return Results.Ok(new ListEstabelecimentosDTO
        {
            Estabelecimentos = result.ToList(),
            TotalCount = totalCount,
        });
    }

    /// <summary>
    /// Retorna o estabelecimetno com o Id</param>
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [HttpGet("{Id}")]
    public async Task<IResult> GetById(long Id)
    {
        var estabelecimento = await _estabelecimentoRepo.GetById(Id);
        if (estabelecimento == null) return Results.BadRequest("Estabelecimento não encontrado.");
        EstabelecimentoDTO toReturn = _mapper.Map<EstabelecimentoDTO>(estabelecimento);

        return Results.Ok(toReturn);
    }

    /// <summary>
    /// Cria um estabelecimmento
    /// </summary>
    /// <param name="estabelecimentoModel"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IResult> CreateEstabelecimento([FromBody] EstabelecimentoDTO estabelecimentoModel)
    {
        if (estabelecimentoModel == null) return Results.BadRequest("Estabelecimento inválido.");

        try
        {
            await _estabelecimentoRepo.Create(_mapper.Map<Estabelecimento>(estabelecimentoModel));
            return Results.Created();
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a gravar Estabelecimento.");
        }
    }

    /// <summary>
    /// Atualiza um estabelecimento
    /// </summary>
    /// <param name="estabelecimentoModel"></param>
    /// <returns></returns>
    [HttpPatch]
    public async Task<IResult> AtualizaEstabelecimento([FromBody] EstabelecimentoDTO estabelecimentoModel)
    {
        if (estabelecimentoModel == null) return Results.BadRequest("Estabelecimento inválido.");

        var estabelecimentoExistente = await _estabelecimentoRepo.GetById(estabelecimentoModel.Id);

        _mapper.Map(estabelecimentoModel, estabelecimentoExistente);

        try
        {
            await _estabelecimentoRepo.Update(estabelecimentoModel.Id, estabelecimentoExistente);
            return Results.Created();
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a atualizar estabelecimento.");
        }
    }

    ///FICHEIROS

    /// <summary>
    /// Retorna o certificado do estabelecimento com o <param name="id"></param>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/CertificadoErs")]
    public IResult GetCertificadoErsByEstabelecimentoId(long id)
    {
        var certificado = _certificadoRepo.GetAll().Where(c => c.EstabelecimentoId == id).Include(c => c.Ficheiro).FirstOrDefault();
        if (certificado == null) return Results.Ok(new CertificadoErsDTO());

        var certificadoDto = _mapper.Map<CertificadoErsDTO>(certificado);
        return Results.Ok(certificadoDto);
    }

    /// <summary>
    /// Retorna o certificado do estabelecimento com o <param name="id"></param>
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/LicencaErs")]
    public IResult GetLicencaErsByEstabelecimentoId(long id)
    {
        var licencas = _licencaRepo.GetAll().Where(c => c.EstabelecimentoId == id).FirstOrDefault();
        if (licencas == null) return Results.Ok(new LicencaErsDTO());

        var licencasDto = _mapper.Map<LicencaErsDTO>(licencas);
        return Results.Ok(licencasDto);
    }

    /// <summary>
    /// Cria um CertificadoERS para um estabelecimento
    /// </summary>
    /// <param name="id"></param>
    /// <param name="certificadoModel"></param>
    /// <returns></returns>
    [HttpPost("{id}/CertificadoErs")]
    public async Task<IResult> CreateCertificadoErs(long id, [FromBody] CertificadoErsDTO certificadoModel)
    {
        if (certificadoModel == null) return Results.BadRequest("Certificado inválido.");

        try
        {
            var certificado = _mapper.Map<CertificadoERS>(certificadoModel);
            certificado.EstabelecimentoId = id;
            await _certificadoRepo.Create(certificado);
            return Results.Created($"/api/Estabelecimento/{id}/CertificadoErs/{certificado.Id}", certificado);
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro ao gravar Certificado.");
        }
    }

    /// <summary>
    /// Cria uma LicencaERS para um estabelecimento
    /// </summary>
    /// <param name="id"></param>
    /// <param name="licencaModel"></param>
    /// <returns></returns>
    [HttpPost("{id}/LicencaErs")]
    public async Task<IResult> CreateLicencaErs(long id, [FromBody] LicencaErsDTO licencaModel)
    {
        if (licencaModel == null) return Results.BadRequest("Licença inválida.");

        try
        {
            var licenca = _mapper.Map<LicencaERS>(licencaModel);
            licenca.EstabelecimentoId = id;
            await _licencaRepo.Create(licenca);
            return Results.Created($"/api/Estabelecimento/{id}/LicencaErs/{licenca.Id}", licenca);
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro ao gravar Licença.");
        }
    }

    /// <summary>
    /// Atualiza um CertificadoERS para um estabelecimento
    /// </summary>
    /// <param name="id"></param>
    /// <param name="certificadoModel"></param>
    /// <returns></returns>
    [HttpPut("{id}/CertificadoErs")]
    public async Task<IResult> UpdateCertificadoErs(long id, [FromBody] CertificadoErsDTO certificadoModel)
    {
        if (certificadoModel == null) return Results.BadRequest("Certificado inválido.");

        var certificadoExistente = await _certificadoRepo.GetById(certificadoModel.Id);
        if (certificadoExistente == null || certificadoExistente.EstabelecimentoId != id)
            return Results.NotFound("Certificado não encontrado para o estabelecimento.");

        _mapper.Map(certificadoModel, certificadoExistente);

        try
        {
            await _certificadoRepo.Update(certificadoModel.Id, certificadoExistente);
            return Results.Ok(certificadoExistente);
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro ao atualizar Certificado.");
        }
    }

    /// <summary>
    /// Atualiza uma LicencaERS para um estabelecimento
    /// </summary>
    /// <param name="id"></param>
    /// <param name="licencaModel"></param>
    /// <returns></returns>
    [HttpPut("{id}/LicencaErs")]
    public async Task<IResult> UpdateLicencaErs(long id, [FromBody] LicencaErsDTO licencaModel)
    {
        if (licencaModel == null) return Results.BadRequest("Licença inválida.");

        var licencaExistente = await _licencaRepo.GetById(licencaModel.Id);
        if (licencaExistente == null || licencaExistente.EstabelecimentoId != id)
            return Results.NotFound("Licença não encontrada para o estabelecimento.");

        _mapper.Map(licencaModel, licencaExistente);

        try
        {
            await _licencaRepo.Update(licencaModel.Id, licencaExistente);
            return Results.Ok(licencaExistente);
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro ao atualizar Licença.");
        }
    }

    /// <summary>
    /// Faz o upload de um ficheiro para o sistema de ficheiros
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    [HttpPost("UploadCertificado")]
    public async Task<IResult> UploadCertificado(IFormFile file)
    {
        // first - save the file to the file system
        string fileLocationAndName = await _fileService.SaveFileToFileSystem(file, _config[UPLOADPATH]);

        return await SaveFicheiro(file.Name, fileLocationAndName);
    }

    private async Task<IResult> SaveFicheiro(string fileName, string fileLocationAndName)
    {
        // second - save the file to the ficheiros table
        Ficheiro ficheiro = new Ficheiro()
        {
            Nome = fileName,
            Localizacao = fileLocationAndName
        };

        try
        {
            await _ficheiroRepo.Create(ficheiro);

            return Results.Ok(_mapper.Map<FicheiroDTO>(ficheiro));
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro a gravar o ficheiro");
        }
    }

    /// <summary>
    /// Grava o ficheiro de licença
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folder"></param>
    /// <returns></returns>
    [HttpPost("UploadLicenca")]
    public async Task<IResult> UploadLicenca(IFormFile file)
    {
        string fileLocationAndName = await _fileService.SaveFileToFileSystem(file, _config[UPLOADPATH]);

        return Results.Ok(fileLocationAndName);
    }

    /// <summary>
    /// Retorna os serviços de um estabelecimento
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}/Servicos")]
    public IResult GetServicosByEstabelecimentoId(long id)
    {
        var servicos = _servicoRepo.GetAll().Where(c => c.EstabelecimentoId == id);
        if (!servicos.Any()) return Results.Ok(servicos);
        var servicosDto = _mapper.Map<IEnumerable<ServicoDTO>>(servicos);
        return Results.Ok(servicosDto);
    }

    // Get api/Estabelecimento/{id}/DirecoesClinicas
    [HttpGet("{id}/DirecoesClinicas")]
    public IResult GetDirecoesClinicasByEstabelecimentoId(long id)
    {
        var direcoesClinicas = _direcaoClinicaRepo.GetAll().Where(c => c.EstabelecimentoId == id);
        if (!direcoesClinicas.Any()) return Results.Ok(direcoesClinicas);
        var direcoesClinicasDto = _mapper.Map<IEnumerable<DirecaoClinicaDTO>>(direcoesClinicas);
        return Results.Ok(direcoesClinicasDto);
    }

    [HttpGet("{id}/CorpoClinico")]
    public IResult GetCorpoClinicoByEstabelecimentoId(long id)
    {
        var colaborador = _colaboradorRepo.GetAll().Where(c => c.EstabelecimentoId == id && c.ColaboradorTipoId == 1);
        if (!colaborador.Any()) return Results.Ok(colaborador);
        var colaboradoresDto = _mapper.Map<IEnumerable<CorpoClinicoDTO>>(colaborador);
        return Results.Ok(colaboradoresDto);
    }

    [HttpPost("{id}/CartaoNipc")]
    public async Task<IResult> CreateCartaoNipc(long id, [FromBody] AnexoDTO CartaoNipc)
    {
        if (CartaoNipc == null) return Results.BadRequest("CartaoNipc inválido.");

        try
        {
            var estabelecimento = await _estabelecimentoRepo.GetById(CartaoNipc.EstabelecimentoId);
            if (estabelecimento is null)
            {
                return Results.NotFound();
            }

            estabelecimento.CartaoNipc = _mapper.Map<Anexo>(CartaoNipc);

            await _estabelecimentoRepo.Update(estabelecimento.Id, estabelecimento);

            return Results.Created($"/api/Estabelecimento/{id}/CartaoNipc/{estabelecimento.CartaoNipc.Id}", estabelecimento.CartaoNipc);
        }
        catch (Exception)
        {
            return Results.InternalServerError("Erro ao gravar o Cartão.");
        }
    }

}
