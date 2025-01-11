using ApiModel;
using ApiModel.Models;

using System.Diagnostics;

namespace BaseDbMigrations;
public class SeedDataWeges(IServiceProvider serviceProvider,
                         IHostEnvironment hostEnvironment,
                         IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    private readonly ActivitySource _activitySource = new(hostEnvironment.ApplicationName);

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var activity = _activitySource.StartActivity(hostEnvironment.ApplicationName, ActivityKind.Client);

        try
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<WegesDbContext>();

            SeedDatabase(dbContext);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }

        hostApplicationLifetime.StopApplication();
        return Task.CompletedTask;
    }

    private static void SeedDatabase(WegesDbContext dbContext)
    {
        if (!dbContext.Set<Entidade>().Any())
        {
            dbContext.Set<Entidade>().AddRange(new[]
            {
                new Entidade
                {
                    Id = 1,
                    Denominacao = "Entidade 1",
                    Morada = "Rua do Teste 1",
                    NifNipc = "123123123",
                    Telefone = "921111111",
                    Email = "emailteste@email.email",
                    Sigla = "ent1",
                    NrERS = "A-1234",
                    EmailNotificacoesERS = "emailnotificacoes@email.email",
                    EmailNotificacoesGerais = "emailnotificacoes@email.email"
                },
                new Entidade
                {
                    Id = 2,
                    Denominacao = "Entidade 2",
                    Morada = "Rua do Teste 2",
                    NifNipc = "123123123",
                    Telefone = "921111111",
                    Email = "emailteste@email.email",
                    Sigla = "ent2",
                    NrERS = "A-1234",
                    EmailNotificacoesERS = "emailnotificacoes@email.email",
                    EmailNotificacoesGerais = "emailnotificacoes@email.email"
                }
            });

            dbContext.SaveChanges();
        }
        if (!dbContext.Set<DirecaoClinica>().Any())
        {
            dbContext.Set<DirecaoClinica>().AddRange(new[]
            {
                new DirecaoClinica
                {
                    Id = 1,
                    Nome = "Nome 1",
                    Cargo = "Cargo 1",
                    Identificacao = "Identificacao 1",
                    ValidadeIdentificacao = new DateOnly(2023, 02, 20),
                    Cedula = "Cedula 1",
                    Ordem = "Ordem 1",
                    Especialidade = "Especialidade 1",
                    EspecialidadeId = 1,
                    Observacoes = "Observacoes 1",
                    EstabelecimentoId = 1
                },
                new DirecaoClinica
                {
                    Id = 2,
                    Nome = "Nome 2",
                    Cargo = "Cargo 2",
                    Identificacao = "Identificacao 2",
                    ValidadeIdentificacao = new DateOnly(2023, 02, 20),
                    Cedula = "Cedula 2",
                    Ordem = "Ordem 2",
                    Especialidade = "Especialidade 2",
                    EspecialidadeId = 2,
                    Observacoes = "Observacoes 2",
                    EstabelecimentoId = 2
                }
            });
            dbContext.SaveChanges();
        }
        if (!dbContext.Set<Servico>().Any())
        {
            dbContext.Set<Servico>().AddRange(new[]
            {
                new Servico
                {
                    Id = 1,
                    Nome = "Servico 1",
                    DataInicio = new DateOnly(2023, 02, 20),
                    Responsavel = "Responsavel 1",
                    Horario = "Horario 1",
                    Observacoes = "Observacoes 1",
                    EstabelecimentoId = 1
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Servico 2",
                    DataInicio = new DateOnly(2023, 02, 20),
                    Responsavel = "Responsavel 2",
                    Horario = "Horario 2",
                    Observacoes = "Observacoes 2",
                    EstabelecimentoId = 2
                }
            });
            dbContext.SaveChanges();
        }
        if (!dbContext.Set<Ficheiro>().Any())
        {
            dbContext.Set<Ficheiro>().AddRange(new[]
            {
                new Ficheiro
                {
                    Id = 1,
                    Nome = "Ficheiro 1",
                    Localizacao = "/shift/exemplo1.txt",
                    Tipo = "Tipo 1"
                },
                new Ficheiro
                {
                    Id = 2,
                    Nome = "Ficheiro 2",
                    Localizacao = "/shift/exemplo100.txt",
                    Tipo = "Tipo 2"
                }
            });
            dbContext.SaveChanges();
        }
        if (!dbContext.Set<Estabelecimento>().Any())
        {
            dbContext.Set<Estabelecimento>().AddRange(new[]
            {
                new Estabelecimento
                {
                    Id = 1,
                    Denominacao = "Estabelecimento 11",
                    Email = "email@email.email",
                    InicioAtividade = new DateOnly(2020, 02, 20),
                    Morada = "estab 1 morada",
                    Sigla = "estab1",
                    Telefone = "291111111",
                    TipoPrestador = "Tipo de Prestador"
                },
                new Estabelecimento
                {
                    Id = 2,
                    Denominacao = "Estabelecimento 2",
                    Email = "email@email.email",
                    InicioAtividade = new DateOnly(2023, 02, 20),
                    Morada = "estab 2 morada",
                    Sigla = "estab2",
                    Telefone = "291111112",
                    TipoPrestador = "Tipo de Prestador"
                }
            });
            dbContext.SaveChanges();
        }
        if (!dbContext.Set<CertificadoERS>().Any())
        {
            dbContext.Set<CertificadoERS>().AddRange(new[]
            {
                new CertificadoERS
                {
                    Id = 1,
                    DataExpiracao = new DateOnly(2023, 02, 20),
                    DataPagamentoTaxa = new DateOnly(2023, 02, 20),
                    EstabelecimentoId = 1,
                    FicheiroId = 1,
                    Periodo = "Periodo 1",
                    NrCertificado = "Nr Certificado 1",
                    DataSubmissao = new DateOnly(2023, 02, 20),
                    Observacoes = "Observacoes 1",
                    DataExpiracaoTaxa = new DateOnly(2023, 02, 20)
                },
                new CertificadoERS
                {
                    Id = 2,
                    DataExpiracao = new DateOnly(2023, 02, 20),
                    DataPagamentoTaxa = new DateOnly(2023, 02, 20),
                    EstabelecimentoId = 2,
                    FicheiroId = 2,
                    Periodo = "Periodo 1",
                    NrCertificado = "Nr Certificado 1",
                    DataSubmissao = new DateOnly(2023, 02, 20),
                    Observacoes = "Observacoes 1",
                    DataExpiracaoTaxa = new DateOnly(2023, 02, 20)
                }
            });
            dbContext.SaveChanges();
        }
        if (!dbContext.Set<LicencaERS>().Any())
        {
            dbContext.Set<LicencaERS>().AddRange(new[]
            {
                new LicencaERS
                {
                    Id = 1,
                    DataSubmissao = new DateOnly(2023, 02, 20),
                    Estabelecimento = dbContext.Set<Estabelecimento>().Find(1L),
                    EstabelecimentoId = 1L,
                    FicheiroId = 1L,
                    NrLicenca = "NrLicenca 1",
                    Ficheiro = dbContext.Set<Ficheiro>().Find(1L),
                    Periodo = "Periodo 1",
                    Observacoes = "Observacoes 1"
                },
                new LicencaERS
                {
                    Id = 2,
                    DataSubmissao = new DateOnly(2023, 02, 20),
                    Estabelecimento = dbContext.Set<Estabelecimento>().Find(2L),
                    EstabelecimentoId = 2L,
                    FicheiroId = 2L,
                    NrLicenca = "NrLicenca 2",
                    Ficheiro = dbContext.Set<Ficheiro>().Find(2L),
                    Periodo = "Periodo 2",
                    Observacoes = "Observacoes 2"
                }
            });
            dbContext.SaveChanges();
        }

    }
}
