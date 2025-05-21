using ApiModel;
using ApiModel.NeoModels;

using Microsoft.EntityFrameworkCore;

using System.Diagnostics;

namespace BaseDbMigrations;

public class DbInitializer(
    IServiceProvider serviceProvider,
    IHostEnvironment hostEnvironment,
    IHostApplicationLifetime hostApplicationLifetime) : BackgroundService
{
    private readonly ActivitySource _activitySource = new(hostEnvironment.ApplicationName);

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var activity = _activitySource.StartActivity(hostEnvironment.ApplicationName, ActivityKind.Client);

        try
        {
            using var scope = serviceProvider.CreateScope();
            var wegesDbContext = scope.ServiceProvider.GetRequiredService<WegesDbContext>();
            var utilizadoresDbContext = scope.ServiceProvider.GetRequiredService<UtilizadoresDbContext>();

            RunMigration(wegesDbContext);
            RunMigration(utilizadoresDbContext);
            SeedDatabase(wegesDbContext);
        }
        catch (Exception ex)
        {
            activity?.AddException(ex);
            throw;
        }

        hostApplicationLifetime.StopApplication();

        return Task.CompletedTask;
    }

    private static void RunMigration(DbContext dbContext)
    {
        dbContext.Database.Migrate();
    }

    /// <summary>
    /// Seed Database
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedDatabase(WegesDbContext dbContext)
    {
        if (!dbContext.Set<Entidade>().Any())
        {
            SeedEntidades(dbContext);
        }
        if (!dbContext.Set<DirecaoClinica>().Any())
        {
            SeedDirecoesClinicas(dbContext);
        }
        if (!dbContext.Set<Servico>().Any())
        {
            SeedServicos(dbContext);
        }
        if (!dbContext.Set<Estabelecimento>().Any())
        {
            SeedEstabelecimentos(dbContext);
        }
    }


    /// <summary>
    /// Seed Estabelecimentos
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedEstabelecimentos(WegesDbContext dbContext)
    {
        if (!dbContext.Set<Estabelecimento>().Any())
        {
            dbContext.Set<Estabelecimento>().AddRange(new[]
            {
                new Estabelecimento
                {
                    Denominacao = "Clínica A",
                    Email = "email@email.email",
                    DataInicioAtividade = new DateOnly(2020, 02, 20),
                    Morada = "estab 1 morada",
                    Sigla = "estab1",
                    Telefone = "291111111",
                    TipoPrestador = "Tipo de Prestador"
                },
                new Estabelecimento
                {
                    Denominacao = "Centro Hospitalar B",
                    Email = "email@email.email",
                    DataInicioAtividade = new DateOnly(2023, 02, 20),
                    Morada = "estab 2 morada",
                    Sigla = "estab2",
                    Telefone = "291111112",
                    TipoPrestador = "Tipo de Prestador"
                },
                new Estabelecimento
                {
                    Denominacao = "Hospital C",
                    Email = "hospitalc@email.com",
                    DataInicioAtividade = new DateOnly(2019, 05, 15),
                    Morada = "Rua do Hospital C, 123",
                    Sigla = "HOSP-C",
                    Telefone = "291111113",
                    TipoPrestador = "Hospital Geral"
                },
                new Estabelecimento
                {
                    Denominacao = "Clínica D",
                    Email = "clinicad@email.com",
                    DataInicioAtividade = new DateOnly(2021, 07, 10),
                    Morada = "Av. Clínica D, 456",
                    Sigla = "CLIN-D",
                    Telefone = "291111114",
                    TipoPrestador = "Clínica Especializada"
                },
                new Estabelecimento
                {
                    Denominacao = "Centro Médico E",
                    Email = "centromedicoe@email.com",
                    DataInicioAtividade = new DateOnly(2022, 09, 25),
                    Morada = "Rua Centro Médico E, 789",
                    Sigla = "MED-E",
                    Telefone = "291111115",
                    TipoPrestador = "Centro Médico"
                },
                new Estabelecimento
                {
                    Denominacao = "Hospital Universitário F",
                    Email = "hospitalf@email.com",
                    DataInicioAtividade = new DateOnly(2018, 11, 05),
                    Morada = "Av. Universitária F, 321",
                    Sigla = "UNIV-F",
                    Telefone = "291111116",
                    TipoPrestador = "Hospital Universitário"
                },
                new Estabelecimento
                {
                    Denominacao = "Policlínica G",
                    Email = "policlinicag@email.com",
                    DataInicioAtividade = new DateOnly(2020, 03, 15),
                    Morada = "Rua Policlínica G, 654",
                    Sigla = "POLI-G",
                    Telefone = "291111117",
                    TipoPrestador = "Policlínica"
                },
                new Estabelecimento
                {
                    Denominacao = "Centro de Saúde H",
                    Email = "centrosaudelh@email.com",
                    DataInicioAtividade = new DateOnly(2019, 06, 20),
                    Morada = "Rua Centro Saúde H, 987",
                    Sigla = "SAUDE-H",
                    Telefone = "291111118",
                    TipoPrestador = "Centro de Saúde"
                },
                new Estabelecimento
                {
                    Denominacao = "Clínica Especializada I",
                    Email = "clinicai@email.com",
                    DataInicioAtividade = new DateOnly(2021, 01, 10),
                    Morada = "Av. Clínica I, 567",
                    Sigla = "CLIN-I",
                    Telefone = "291111119",
                    TipoPrestador = "Clínica Especializada"
                },
                new Estabelecimento
                {
                    Denominacao = "Hospital Municipal J",
                    Email = "hospitalj@email.com",
                    DataInicioAtividade = new DateOnly(2020, 12, 01),
                    Morada = "Rua Municipal J, 234",
                    Sigla = "MUNI-J",
                    Telefone = "291111120",
                    TipoPrestador = "Hospital Municipal"
                },
                new Estabelecimento
                {
                    Denominacao = "Centro Clínico K",
                    Email = "centroclinicok@email.com",
                    DataInicioAtividade = new DateOnly(2017, 08, 22),
                    Morada = "Av. Centro Clínico K, 890",
                    Sigla = "CLIN-K",
                    Telefone = "291111121",
                    TipoPrestador = "Centro Clínico"
                },
                new Estabelecimento
                {
                    Denominacao = "Unidade de Saúde L",
                    Email = "unidadel@email.com",
                    DataInicioAtividade = new DateOnly(2023, 04, 05),
                    Morada = "Rua Unidade L, 123",
                    Sigla = "US-L",
                    Telefone = "291111122",
                    TipoPrestador = "Unidade Básica de Saúde"
                }

            });
            dbContext.SaveChanges();
        }
    }
    /// <summary>
    /// Seed Servicos
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedServicos(WegesDbContext dbContext)
    {
        if (!dbContext.Set<Servico>().Any())
        {
            dbContext.Set<Servico>().AddRange(new[]
            {
                new Servico
                {
                    Denominacao = "Medicina Dentária",
                    Diretor = "João A.",
                    DiretorCC = "CC 12345678",
                    DiretorCcDataValidade = new DateOnly(2023, 12, 31),
                    DiretorCedulaProfissional = "Cedula 123456",
                    DiretorOrdem = "Ordem 123456",
                    DeclaracaoAceitacao = "Aceito as condições",
                    Especialidade = "Dentária",
                    Horario = "08:00 - 17:00"
                },
                new Servico
                {
                    Denominacao = "Cardiologia",
                    Diretor = "Maria T.",
                    DiretorCC = "CC 23456789",
                    DiretorCcDataValidade = new DateOnly(2025, 06, 15),
                    DiretorCedulaProfissional = "Cedula 234567",
                    DiretorOrdem = "Ordem 234567",
                    DeclaracaoAceitacao = "Aceito os termos",
                    Especialidade = "Cardiovascular",
                    Horario = "09:00 - 18:00"
                },
                new Servico
                {
                    Denominacao = "Pediatria",
                    Diretor = "Carlos M.",
                    DiretorCC = "CC 34567890",
                    DiretorCcDataValidade = new DateOnly(2024, 11, 30),
                    DiretorCedulaProfissional = "Cedula 345678",
                    DiretorOrdem = "Ordem 345678",
                    DeclaracaoAceitacao = "Declaro estar de acordo",
                    Especialidade = "Pediátrica",
                    Horario = "07:30 - 16:30"
                },
                new Servico
                {
                    Denominacao = "Dermatologia",
                    Diretor = "Ana L.",
                    DiretorCC = "CC 45678901",
                    DiretorCcDataValidade = new DateOnly(2026, 03, 10),
                    DiretorCedulaProfissional = "Cedula 456789",
                    DiretorOrdem = "Ordem 456789",
                    DeclaracaoAceitacao = "Confirmo a aceitação",
                    Especialidade = "Dermatológica",
                    Horario = "10:00 - 19:00"
                },
                new Servico
                {
                    Denominacao = "Ortopedia",
                    Diretor = "Bruno S.",
                    DiretorCC = "CC 56789012",
                    DiretorCcDataValidade = new DateOnly(2025, 09, 25),
                    DiretorCedulaProfissional = "Cedula 567890",
                    DiretorOrdem = "Ordem 567890",
                    DeclaracaoAceitacao = "Aceito os regulamentos",
                    Especialidade = "Ortopédica",
                    Horario = "08:00 - 17:00"
                },
                new Servico
                {
                    Denominacao = "Ginecologia",
                    Diretor = "Sara P.",
                    DiretorCC = "CC 67890123",
                    DiretorCcDataValidade = new DateOnly(2027, 01, 20),
                    DiretorCedulaProfissional = "Cedula 678901",
                    DiretorOrdem = "Ordem 678901",
                    DeclaracaoAceitacao = "Li e aceito as condições",
                    Especialidade = "Ginecológica",
                    Horario = "09:00 - 18:00"
                },
                new Servico
                {
                    Denominacao = "Oftalmologia",
                    Diretor = "Miguel F.",
                    DiretorCC = "CC 78901234",
                    DiretorCcDataValidade = new DateOnly(2024, 07, 05),
                    DiretorCedulaProfissional = "Cedula 789012",
                    DiretorOrdem = "Ordem 789012",
                    DeclaracaoAceitacao = "Declaro estar de acordo",
                    Especialidade = "Ocular",
                    Horario = "08:30 - 17:30"
                },
                new Servico
                {
                    Denominacao = "Neurologia",
                    Diretor = "Helena R.",
                    DiretorCC = "CC 89012345",
                    DiretorCcDataValidade = new DateOnly(2025, 10, 01),
                    DiretorCedulaProfissional = "Cedula 890123",
                    DiretorOrdem = "Ordem 890123",
                    DeclaracaoAceitacao = "Aceito integralmente",
                    Especialidade = "Neurológica",
                    Horario = "10:00 - 19:00"
                },
                new Servico
                {
                    Denominacao = "Psiquiatria",
                    Diretor = "Ricardo N.",
                    DiretorCC = "CC 90123456",
                    DiretorCcDataValidade = new DateOnly(2023, 12, 31),
                    DiretorCedulaProfissional = "Cedula 901234",
                    DiretorOrdem = "Ordem 901234",
                    DeclaracaoAceitacao = "Confirmo a aceitação",
                    Especialidade = "Psiquiátrica",
                    Horario = "08:00 - 16:00"
                },
                new Servico
                {
                    Denominacao = "Otorrinolaringologia",
                    Diretor = "Patrícia G.",
                    DiretorCC = "CC 01234567",
                    DiretorCcDataValidade = new DateOnly(2026, 04, 12),
                    DiretorCedulaProfissional = "Cedula 012345",
                    DiretorOrdem = "Ordem 012345",
                    DeclaracaoAceitacao = "Aceito as condições definidas",
                    Especialidade = "Otorrino",
                    Horario = "09:30 - 18:30"
                },
                new Servico
                {
                    Denominacao = "Endocrinologia",
                    Diretor = "Tiago V.",
                    DiretorCC = "CC 13243546",
                    DiretorCcDataValidade = new DateOnly(2028, 02, 18),
                    DiretorCedulaProfissional = "Cedula 132435",
                    DiretorOrdem = "Ordem 132435",
                    DeclaracaoAceitacao = "Li e aceito",
                    Especialidade = "Endócrina",
                    Horario = "07:00 - 15:00"
                }
            });
            dbContext.SaveChanges();
        }
    }
    /// <summary>
    /// Seed Entidades
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedEntidades(WegesDbContext dbContext)
    {
        if (!dbContext.Set<Entidade>().Any())
        {
            dbContext.Set<Entidade>().AddRange(new[]
            {
                new Entidade
                {
                    Nome = "Entidade 1"

                },
                new Entidade
                {
                    Nome = "Entidade 2"
                }
            });

            dbContext.SaveChanges();
        }
    }
    /// <summary>
    /// Seed DirecoesClinicas
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedDirecoesClinicas(WegesDbContext dbContext)
    {
        if (!dbContext.Set<DirecaoClinica>().Any())
        {
            dbContext.Set<DirecaoClinica>().AddRange(new[]
            {
                new DirecaoClinica
                {
                    Nome = "Nome 1",
                    CC = "CC 1",
                    CcDataValidade = new DateOnly(2023, 12, 31),
                    CedulaProfissional = "Cedula 1",
                    Ordem = "Ordem 1",
                    CedulaDataValidade = new DateOnly(2023, 12, 31),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Especialidade 1",
                    SubDiretor = "Alberto Jerónimo",
                    SubDiretorCC = "CC 2",
                    SubDiretorCcDataValidade = new DateOnly(2023, 12, 31),
                    SubDiretorCedulaProfissional = "Cedula 2",
                    SubDiretorOrdem = "Ordem 2",
                    SubDiretorCedulaDataValidade = new DateOnly(2023, 12, 31)
                },
                new DirecaoClinica
                {
                    Nome = "Dra. Mariana Silva",
                    CC = "CC 1001",
                    CcDataValidade = new DateOnly(2025, 05, 20),
                    CedulaProfissional = "Cedula 1001",
                    Ordem = "Ordem 1001",
                    CedulaDataValidade = new DateOnly(2027, 10, 15),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Cardiologia",
                    SubDiretor = "Dr. Pedro Ramos",
                    SubDiretorCC = "CC 2001",
                    SubDiretorCcDataValidade = new DateOnly(2026, 03, 12),
                    SubDiretorCedulaProfissional = "Cedula 2001",
                    SubDiretorOrdem = "Ordem 2001",
                    SubDiretorCedulaDataValidade = new DateOnly(2027, 09, 20)
                },
                new DirecaoClinica
                {
                    Nome = "Dr. António Lopes",
                    CC = "CC 1002",
                    CcDataValidade = new DateOnly(2024, 08, 31),
                    CedulaProfissional = "Cedula 1002",
                    Ordem = "Ordem 1002",
                    CedulaDataValidade = new DateOnly(2026, 12, 01),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Ortopedia",
                    SubDiretor = "Dra. Joana Matos",
                    SubDiretorCC = "CC 2002",
                    SubDiretorCcDataValidade = new DateOnly(2025, 06, 30),
                    SubDiretorCedulaProfissional = "Cedula 2002",
                    SubDiretorOrdem = "Ordem 2002",
                    SubDiretorCedulaDataValidade = new DateOnly(2026, 11, 10)
                },
                new DirecaoClinica
                {
                    Nome = "Dra. Inês Ferreira",
                    CC = "CC 1003",
                    CcDataValidade = new DateOnly(2026, 01, 14),
                    CedulaProfissional = "Cedula 1003",
                    Ordem = "Ordem 1003",
                    CedulaDataValidade = new DateOnly(2028, 04, 07),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Ginecologia",
                    SubDiretor = "Dr. Ricardo Esteves",
                    SubDiretorCC = "CC 2003",
                    SubDiretorCcDataValidade = new DateOnly(2025, 07, 21),
                    SubDiretorCedulaProfissional = "Cedula 2003",
                    SubDiretorOrdem = "Ordem 2003",
                    SubDiretorCedulaDataValidade = new DateOnly(2027, 05, 30)
                },
                new DirecaoClinica
                {
                    Nome = "Dr. Manuel Costa",
                    CC = "CC 1004",
                    CcDataValidade = new DateOnly(2025, 12, 31),
                    CedulaProfissional = "Cedula 1004",
                    Ordem = "Ordem 1004",
                    CedulaDataValidade = new DateOnly(2027, 09, 15),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Neurologia",
                    SubDiretor = "Dra. Beatriz Pires",
                    SubDiretorCC = "CC 2004",
                    SubDiretorCcDataValidade = new DateOnly(2026, 08, 19),
                    SubDiretorCedulaProfissional = "Cedula 2004",
                    SubDiretorOrdem = "Ordem 2004",
                    SubDiretorCedulaDataValidade = new DateOnly(2027, 12, 05)
                },
                new DirecaoClinica
                {
                    Nome = "Dra. Filipa Marques",
                    CC = "CC 1005",
                    CcDataValidade = new DateOnly(2024, 04, 10),
                    CedulaProfissional = "Cedula 1005",
                    Ordem = "Ordem 1005",
                    CedulaDataValidade = new DateOnly(2026, 06, 01),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Pediatria",
                    SubDiretor = "Dr. André Nogueira",
                    SubDiretorCC = "CC 2005",
                    SubDiretorCcDataValidade = new DateOnly(2025, 03, 15),
                    SubDiretorCedulaProfissional = "Cedula 2005",
                    SubDiretorOrdem = "Ordem 2005",
                    SubDiretorCedulaDataValidade = new DateOnly(2026, 11, 17)
                },
                new DirecaoClinica
                {
                    Nome = "Dr. Tiago Gonçalves",
                    CC = "CC 1006",
                    CcDataValidade = new DateOnly(2026, 09, 25),
                    CedulaProfissional = "Cedula 1006",
                    Ordem = "Ordem 1006",
                    CedulaDataValidade = new DateOnly(2027, 08, 11),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Dermatologia",
                    SubDiretor = "Dra. Carolina Reis",
                    SubDiretorCC = "CC 2006",
                    SubDiretorCcDataValidade = new DateOnly(2026, 12, 24),
                    SubDiretorCedulaProfissional = "Cedula 2006",
                    SubDiretorOrdem = "Ordem 2006",
                    SubDiretorCedulaDataValidade = new DateOnly(2027, 07, 01)
                },
                new DirecaoClinica
                {
                    Nome = "Dra. Helena Matias",
                    CC = "CC 1007",
                    CcDataValidade = new DateOnly(2025, 11, 03),
                    CedulaProfissional = "Cedula 1007",
                    Ordem = "Ordem 1007",
                    CedulaDataValidade = new DateOnly(2028, 02, 14),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Endocrinologia",
                    SubDiretor = "Dr. Nuno Barros",
                    SubDiretorCC = "CC 2007",
                    SubDiretorCcDataValidade = new DateOnly(2026, 04, 09),
                    SubDiretorCedulaProfissional = "Cedula 2007",
                    SubDiretorOrdem = "Ordem 2007",
                    SubDiretorCedulaDataValidade = new DateOnly(2027, 10, 22)
                },
                new DirecaoClinica
                {
                    Nome = "Dr. Jorge Neves",
                    CC = "CC 1008",
                    CcDataValidade = new DateOnly(2027, 01, 30),
                    CedulaProfissional = "Cedula 1008",
                    Ordem = "Ordem 1008",
                    CedulaDataValidade = new DateOnly(2028, 06, 06),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Oncologia",
                    SubDiretor = "Dra. Isabel Sousa",
                    SubDiretorCC = "CC 2008",
                    SubDiretorCcDataValidade = new DateOnly(2026, 02, 28),
                    SubDiretorCedulaProfissional = "Cedula 2008",
                    SubDiretorOrdem = "Ordem 2008",
                    SubDiretorCedulaDataValidade = new DateOnly(2027, 08, 19)
                },
                new DirecaoClinica
                {
                    Nome = "Dra. Cláudia Rocha",
                    CC = "CC 1009",
                    CcDataValidade = new DateOnly(2025, 07, 07),
                    CedulaProfissional = "Cedula 1009",
                    Ordem = "Ordem 1009",
                    CedulaDataValidade = new DateOnly(2027, 05, 05),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Reumatologia",
                    SubDiretor = "Dr. Luís Ventura",
                    SubDiretorCC = "CC 2009",
                    SubDiretorCcDataValidade = new DateOnly(2026, 11, 11),
                    SubDiretorCedulaProfissional = "Cedula 2009",
                    SubDiretorOrdem = "Ordem 2009",
                    SubDiretorCedulaDataValidade = new DateOnly(2028, 03, 03)
                },
                new DirecaoClinica
                {
                    Nome = "Dr. Paulo Almeida",
                    CC = "CC 1010",
                    CcDataValidade = new DateOnly(2024, 10, 12),
                    CedulaProfissional = "Cedula 1010",
                    Ordem = "Ordem 1010",
                    CedulaDataValidade = new DateOnly(2026, 01, 27),
                    DeclaracaoAceitacao = true,
                    Especialidade = "Psiquiatria",
                    SubDiretor = "Dra. Sílvia Figueiredo",
                    SubDiretorCC = "CC 2010",
                    SubDiretorCcDataValidade = new DateOnly(2025, 12, 22),
                    SubDiretorCedulaProfissional = "Cedula 2010",
                    SubDiretorOrdem = "Ordem 2010",
                    SubDiretorCedulaDataValidade = new DateOnly(2026, 09, 09)
                }
            });
            dbContext.SaveChanges();
        }
    }
}