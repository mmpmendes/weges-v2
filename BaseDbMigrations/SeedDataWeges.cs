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
                    EstabelecimentoId = 1,
                    TipologiaId = 1,
                    Tipologia = "Tipologia 1"
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
                    EstabelecimentoId = 2,
                    TipologiaId = 2,
                    Tipologia = "Tipologia 2"
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
                    TipologiaId = 1,
                    Horario = "Horario 1",
                    Observacoes = "Observacoes 1",
                    EstabelecimentoId = 1,
                    Tipologia = "Tipologia 1"
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Servico 2",
                    DataInicio = new DateOnly(2023, 02, 20),
                    Responsavel = "Responsavel 2",
                    TipologiaId = 2,
                    Horario = "Horario 2",
                    Observacoes = "Observacoes 2",
                    EstabelecimentoId = 2,
                    Tipologia = "Tipologia 2"
                }
            });
            dbContext.SaveChanges();
        }
    }
}
