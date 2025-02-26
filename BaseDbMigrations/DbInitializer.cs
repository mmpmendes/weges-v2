using ApiModel;
using ApiModel.Models;

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
        if (!dbContext.Set<Ficheiro>().Any())
        {
            SeedFicheiros(dbContext);
        }
        if (!dbContext.Set<Estabelecimento>().Any())
        {
            SeedEstabelecimentos(dbContext);
        }
        if (!dbContext.Set<CertificadoERS>().Any())
        {
            SeedCertificados(dbContext);
        }
        if (!dbContext.Set<LicencaERS>().Any())
        {
            SeedLicencas(dbContext);
        }
        if (!dbContext.Set<AnexoTipo>().Any())
        {
            SeedAnexoTipo(dbContext);
        }
        if (!dbContext.Set<ColaboradorTipo>().Any())
        {
            SeedColaboradorTipo(dbContext);
        }
        if (!dbContext.Set<Colaborador>().Any())
        {
            SeedColaboradores(dbContext);
        }
    }
    /// <summary>
    /// Seed Colaboradores
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedColaboradores(WegesDbContext dbContext)
    {

        dbContext.Set<Colaborador>().AddRange(new[]
        {
           new Colaborador
        {
            Id = 1,
            Nome = "Ana Silva",
            NrIdentificacao = "123456789",
            DataNascimento = new DateOnly(1985, 6, 15),
            InicioAtividade = new DateOnly(2020, 1, 10),
            Cedula = "C-12345",
            Especialidade = "Cardiologia",
            Estado = true,
            TotalHoras = 40,
            Observacoes = "Colaboradora exemplar.",
            ServicoId = 1,
            EstabelecimentoId = 1,
            ColaboradorTipoId = 1
        },
        new Colaborador
        {
            Id = 2,
            Nome = "João Pereira",
            NrIdentificacao = "987654321",
            DataNascimento = new DateOnly(1990, 3, 10),
            InicioAtividade = new DateOnly(2021, 5, 15),
            Cedula = "C-67890",
            Especialidade = "Pediatria",
            Estado = true,
            TotalHoras = 35,
            Observacoes = "Trabalha bem com crianças.",
            ServicoId = 2,
            EstabelecimentoId = 1,
            ColaboradorTipoId = 2
        },
        new Colaborador
        {
            Id = 3,
            Nome = "Maria Fernandes",
            NrIdentificacao = "456123789",
            DataNascimento = new DateOnly(1978, 12, 22),
            InicioAtividade = new DateOnly(2015, 9, 1),
            Cedula = "C-11223",
            Especialidade = "Neurologia",
            Estado = false,
            TotalHoras = 20,
            Observacoes = "Atualmente em licença médica.",
            ServicoId = 3,
            EstabelecimentoId = 2,
            ColaboradorTipoId = 1
        },
        new Colaborador
        {
            Id = 4,
            Nome = "Carlos Oliveira",
            NrIdentificacao = "789456123",
            DataNascimento = new DateOnly(1980, 8, 14),
            InicioAtividade = new DateOnly(2018, 3, 12),
            Cedula = "C-33456",
            Especialidade = "Ortopedia",
            Estado = true,
            TotalHoras = 45,
            Observacoes = "Experiente em casos complexos.",
            ServicoId = 4,
            EstabelecimentoId = 3,
            ColaboradorTipoId = 2
        },
        new Colaborador
        {
            Id = 5,
            Nome = "Patrícia Gomes",
            NrIdentificacao = "852741963",
            DataNascimento = new DateOnly(1992, 11, 5),
            InicioAtividade = new DateOnly(2019, 7, 20),
            Cedula = "C-98765",
            Especialidade = "Gastroenterologia",
            Estado = true,
            TotalHoras = 38,
            Observacoes = "Muito atenciosa com os pacientes.",
            ServicoId = 1,
            EstabelecimentoId = 1,
            ColaboradorTipoId = 1
        },
        new Colaborador
        {
            Id = 6,
            Nome = "Rafael Costa",
            NrIdentificacao = "951753852",
            DataNascimento = new DateOnly(1987, 4, 19),
            InicioAtividade = new DateOnly(2016, 6, 8),
            Cedula = "C-65432",
            Especialidade = "Pediatria",
            Estado = true,
            TotalHoras = 40,
            Observacoes = "Bom com consultas de crianças.",
            ServicoId = 2,
            EstabelecimentoId = 2,
            ColaboradorTipoId = 1
        },
        new Colaborador
        {
            Id = 7,
            Nome = "Sandra Rodrigues",
            NrIdentificacao = "753159852",
            DataNascimento = new DateOnly(1990, 2, 28),
            InicioAtividade = new DateOnly(2020, 9, 15),
            Cedula = "C-99887",
            Especialidade = "Cardiologia",
            Estado = true,
            TotalHoras = 42,
            Observacoes = "Dedicada e profissional.",
            ServicoId = 1,
            EstabelecimentoId = 3,
            ColaboradorTipoId = 2
        },
        new Colaborador
        {
            Id = 8,
            Nome = "Fernando Mendes",
            NrIdentificacao = "789123456",
            DataNascimento = new DateOnly(1984, 7, 7),
            InicioAtividade = new DateOnly(2017, 10, 25),
            Cedula = "C-55432",
            Especialidade = "Neurologia",
            Estado = false,
            TotalHoras = 25,
            Observacoes = "Em licença temporária.",
            ServicoId = 3,
            EstabelecimentoId = 1,
            ColaboradorTipoId = 1
        },
        new Colaborador
        {
            Id = 9,
            Nome = "Clara Vieira",
            NrIdentificacao = "951357852",
            DataNascimento = new DateOnly(1991, 6, 18),
            InicioAtividade = new DateOnly(2021, 3, 1),
            Cedula = "C-87654",
            Especialidade = "Gastroenterologia",
            Estado = true,
            TotalHoras = 37,
            Observacoes = "Atenta aos detalhes.",
            ServicoId = 4,
            EstabelecimentoId = 2,
            ColaboradorTipoId = 2
        },
        new Colaborador
        {
            Id = 10,
            Nome = "Bruno Nunes",
            NrIdentificacao = "852963741",
            DataNascimento = new DateOnly(1983, 3, 15),
            InicioAtividade = new DateOnly(2014, 5, 25),
            Cedula = "C-22345",
            Especialidade = "Ortopedia",
            Estado = true,
            TotalHoras = 45,
            Observacoes = "Com experiência em trauma.",
            ServicoId = 2,
            EstabelecimentoId = 3,
            ColaboradorTipoId = 1
        }
        });
        dbContext.SaveChanges();
    }

    /// <summary>
    /// Seed ColaboradorTipo
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedColaboradorTipo(WegesDbContext dbContext)
    {
        if (!dbContext.Set<ColaboradorTipo>().Any())
        {
            int id = 1;
            dbContext.Set<ColaboradorTipo>().AddRange(new[]
            {
            new ColaboradorTipo
            {
                Id = id++,
                Tipo = "Corpo Clínico"
            },
            new ColaboradorTipo
            {
                Id = id++,
                Tipo = "Administrativo"
            },
            new ColaboradorTipo
            {
                Id = id++,
                Tipo = "Auxiliar"
            }
        });
            dbContext.SaveChanges();
        }
    }

    /// <summary>
    /// Seed AnexoTipo
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedAnexoTipo(WegesDbContext dbContext)
    {
        int id = 1;
        dbContext.Set<AnexoTipo>().AddRange(new[]
        {
            new AnexoTipo
            {
                Id = id++,
                Tipo = "Nipc"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "AlvaraCM"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "MedidasANPC"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "ParecerANPC"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "Lista de Verificacao"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "Ficheiros a Anexar"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "Direitos e Deveres dos Pacientes"
            },
            new AnexoTipo
            {
                Id = id++,
                Tipo = "Licenciamento e Registo Legal"
            }
        });
    }
    /// <summary>
    /// Seed Licencas
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedLicencas(WegesDbContext dbContext)
    {
        //if (!dbContext.Set<LicencaERS>().Any())
        //{
        //    dbContext.Set<LicencaERS>().AddRange(new[]
        //    {
        //        new LicencaERS
        //        {
        //            Id = 1,
        //            DataSubmissao = new DateOnly(2023, 02, 20),
        //            Estabelecimento = dbContext.Set<Estabelecimento>().Find(1L),
        //            EstabelecimentoId = 1L,
        //            FicheiroId = 1L,
        //            NrLicenca = "NrLicenca 1",
        //            Ficheiro = dbContext.Set<Ficheiro>().Find(1L),
        //            Periodo = "Periodo 1",
        //            Observacoes = "Observacoes 1"
        //        },
        //        new LicencaERS
        //        {
        //            Id = 2,
        //            DataSubmissao = new DateOnly(2023, 02, 20),
        //            Estabelecimento = dbContext.Set<Estabelecimento>().Find(2L),
        //            EstabelecimentoId = 2L,
        //            FicheiroId = 2L,
        //            NrLicenca = "NrLicenca 2",
        //            Ficheiro = dbContext.Set<Ficheiro>().Find(2L),
        //            Periodo = "Periodo 2",
        //            Observacoes = "Observacoes 2"
        //        }
        //    });
        //    dbContext.SaveChanges();
        //}
    }
    /// <summary>
    /// Seed Certificados
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedCertificados(WegesDbContext dbContext)
    {
        //if (!dbContext.Set<CertificadoERS>().Any())
        //{
        //    dbContext.Set<CertificadoERS>().AddRange(new[]
        //    {
        //        new CertificadoERS
        //        {
        //            Id = 1,
        //            DataExpiracao = new DateOnly(2023, 02, 20),
        //            DataPagamentoTaxa = new DateOnly(2023, 02, 20),
        //            EstabelecimentoId = 1,
        //            FicheiroId = 1,
        //            Periodo = "Periodo 1",
        //            NrCertificado = "Nr Certificado 1",
        //            DataSubmissao = new DateOnly(2023, 02, 20),
        //            Observacoes = "Observacoes 1",
        //            DataExpiracaoTaxa = new DateOnly(2023, 02, 20)
        //        },
        //        new CertificadoERS
        //        {
        //            Id = 2,
        //            DataExpiracao = new DateOnly(2023, 02, 20),
        //            DataPagamentoTaxa = new DateOnly(2023, 02, 20),
        //            EstabelecimentoId = 2,
        //            FicheiroId = 2,
        //            Periodo = "Periodo 1",
        //            NrCertificado = "Nr Certificado 1",
        //            DataSubmissao = new DateOnly(2023, 02, 20),
        //            Observacoes = "Observacoes 1",
        //            DataExpiracaoTaxa = new DateOnly(2023, 02, 20)
        //        }
        //    });
        //    dbContext.SaveChanges();
        //}
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
                    Id = 1,
                    Denominacao = "Clínica A",
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
                    Denominacao = "Centro Hospitalar B",
                    Email = "email@email.email",
                    InicioAtividade = new DateOnly(2023, 02, 20),
                    Morada = "estab 2 morada",
                    Sigla = "estab2",
                    Telefone = "291111112",
                    TipoPrestador = "Tipo de Prestador"
                },
                new Estabelecimento
                {
                    Id = 3,
                    Denominacao = "Hospital C",
                    Email = "hospitalc@email.com",
                    InicioAtividade = new DateOnly(2019, 05, 15),
                    Morada = "Rua do Hospital C, 123",
                    Sigla = "HOSP-C",
                    Telefone = "291111113",
                    TipoPrestador = "Hospital Geral"
                },
                new Estabelecimento
                {
                    Id = 4,
                    Denominacao = "Clínica D",
                    Email = "clinicad@email.com",
                    InicioAtividade = new DateOnly(2021, 07, 10),
                    Morada = "Av. Clínica D, 456",
                    Sigla = "CLIN-D",
                    Telefone = "291111114",
                    TipoPrestador = "Clínica Especializada"
                },
                new Estabelecimento
                {
                    Id = 5,
                    Denominacao = "Centro Médico E",
                    Email = "centromedicoe@email.com",
                    InicioAtividade = new DateOnly(2022, 09, 25),
                    Morada = "Rua Centro Médico E, 789",
                    Sigla = "MED-E",
                    Telefone = "291111115",
                    TipoPrestador = "Centro Médico"
                },
                new Estabelecimento
                {
                    Id = 6,
                    Denominacao = "Hospital Universitário F",
                    Email = "hospitalf@email.com",
                    InicioAtividade = new DateOnly(2018, 11, 05),
                    Morada = "Av. Universitária F, 321",
                    Sigla = "UNIV-F",
                    Telefone = "291111116",
                    TipoPrestador = "Hospital Universitário"
                },
                new Estabelecimento
                {
                    Id = 7,
                    Denominacao = "Policlínica G",
                    Email = "policlinicag@email.com",
                    InicioAtividade = new DateOnly(2020, 03, 15),
                    Morada = "Rua Policlínica G, 654",
                    Sigla = "POLI-G",
                    Telefone = "291111117",
                    TipoPrestador = "Policlínica"
                },
                new Estabelecimento
                {
                    Id = 8,
                    Denominacao = "Centro de Saúde H",
                    Email = "centrosaudelh@email.com",
                    InicioAtividade = new DateOnly(2019, 06, 20),
                    Morada = "Rua Centro Saúde H, 987",
                    Sigla = "SAUDE-H",
                    Telefone = "291111118",
                    TipoPrestador = "Centro de Saúde"
                },
                new Estabelecimento
                {
                    Id = 9,
                    Denominacao = "Clínica Especializada I",
                    Email = "clinicai@email.com",
                    InicioAtividade = new DateOnly(2021, 01, 10),
                    Morada = "Av. Clínica I, 567",
                    Sigla = "CLIN-I",
                    Telefone = "291111119",
                    TipoPrestador = "Clínica Especializada"
                },
                new Estabelecimento
                {
                    Id = 10,
                    Denominacao = "Hospital Municipal J",
                    Email = "hospitalj@email.com",
                    InicioAtividade = new DateOnly(2020, 12, 01),
                    Morada = "Rua Municipal J, 234",
                    Sigla = "MUNI-J",
                    Telefone = "291111120",
                    TipoPrestador = "Hospital Municipal"
                },
                new Estabelecimento
                {
                    Id = 11,
                    Denominacao = "Centro Clínico K",
                    Email = "centroclinicok@email.com",
                    InicioAtividade = new DateOnly(2017, 08, 22),
                    Morada = "Av. Centro Clínico K, 890",
                    Sigla = "CLIN-K",
                    Telefone = "291111121",
                    TipoPrestador = "Centro Clínico"
                },
                new Estabelecimento
                {
                    Id = 12,
                    Denominacao = "Unidade de Saúde L",
                    Email = "unidadel@email.com",
                    InicioAtividade = new DateOnly(2023, 04, 05),
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
    /// Seed Ficheiros
    /// </summary>
    /// <param name="dbContext"></param>
    private static void SeedFicheiros(WegesDbContext dbContext)
    {
        //if (!dbContext.Set<Ficheiro>().Any())
        //{
        //    dbContext.Set<Ficheiro>().AddRange(new[]
        //    {
        //        new Ficheiro
        //        {
        //            Id = 1,
        //            Nome = "Ficheiro 1",
        //            Localizacao = "/shift/exemplo1.txt",
        //            Tipo = "Tipo 1"
        //        },
        //        new Ficheiro
        //        {
        //            Id = 2,
        //            Nome = "Ficheiro 2",
        //            Localizacao = "/shift/exemplo100.txt",
        //            Tipo = "Tipo 2"
        //        }
        //    });
        //    dbContext.SaveChanges();
        //}
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
                    Id = 1,
                    Nome = "Medicina Dentária",
                    DataInicio = new DateOnly(2023, 02, 20),
                    Responsavel = "João A.",
                    Horario = "Horario 1",
                    Observacoes = "Observacoes 1",
                    EstabelecimentoId = 1
                },
                new Servico
                {
                    Id = 2,
                    Nome = "Endocrinologia",
                    DataInicio = new DateOnly(2023, 02, 20),
                    Responsavel = "Joana B.",
                    Horario = "Horario 2",
                    Observacoes = "Observacoes 2",
                    EstabelecimentoId = 2
                },
                new Servico
                {
                    Id = 3,
                    Nome = "Pediatria",
                    DataInicio = new DateOnly(2022, 06, 15),
                    Responsavel = "Carlos D.",
                    Horario = "09:00 - 17:00",
                    Observacoes = "Atendimento de crianças",
                    EstabelecimentoId = 1
                },
                new Servico
                {
                    Id = 4,
                    Nome = "Cardiologia",
                    DataInicio = new DateOnly(2021, 11, 10),
                    Responsavel = "Maria C.",
                    Horario = "08:00 - 16:00",
                    Observacoes = "Especialista em doenças cardíacas",
                    EstabelecimentoId = 3
                },
                new Servico
                {
                    Id = 5,
                    Nome = "Neurologia",
                    DataInicio = new DateOnly(2020, 05, 18),
                    Responsavel = "Ricardo F.",
                    Horario = "10:00 - 18:00",
                    Observacoes = "Consultas para doenças neurológicas",
                    EstabelecimentoId = 2
                },
                new Servico
                {
                    Id = 6,
                    Nome = "Dermatologia",
                    DataInicio = new DateOnly(2021, 03, 25),
                    Responsavel = "Fernanda L.",
                    Horario = "08:30 - 16:30",
                    Observacoes = "Tratamento de doenças de pele",
                    EstabelecimentoId = 1
                },
                new Servico
                {
                    Id = 7,
                    Nome = "Ortopedia",
                    DataInicio = new DateOnly(2020, 08, 12),
                    Responsavel = "João P.",
                    Horario = "09:00 - 17:00",
                    Observacoes = "Tratamento de fraturas e lesões ósseas",
                    EstabelecimentoId = 3
                },
                new Servico
                {
                    Id = 8,
                    Nome = "Gastroenterologia",
                    DataInicio = new DateOnly(2019, 02, 02),
                    Responsavel = "Pedro R.",
                    Horario = "08:00 - 16:00",
                    Observacoes = "Consultas de doenças digestivas",
                    EstabelecimentoId = 2
                },
                new Servico
                {
                    Id = 9,
                    Nome = "Oftalmologia",
                    DataInicio = new DateOnly(2022, 01, 10),
                    Responsavel = "Luciana S.",
                    Horario = "10:00 - 18:00",
                    Observacoes = "Exames oftalmológicos e cirurgias",
                    EstabelecimentoId = 1
                },
                new Servico
                {
                    Id = 10,
                    Nome = "Fisioterapia",
                    DataInicio = new DateOnly(2021, 07, 30),
                    Responsavel = "Ana T.",
                    Horario = "08:00 - 14:00",
                    Observacoes = "Reabilitação física e motora",
                    EstabelecimentoId = 3
                },
                new Servico
                {
                    Id = 11,
                    Nome = "Urologia",
                    DataInicio = new DateOnly(2023, 03, 05),
                    Responsavel = "Carlos M.",
                    Horario = "09:00 - 17:00",
                    Observacoes = "Tratamento de problemas urológicos",
                    EstabelecimentoId = 2
                },
                new Servico
                {
                    Id = 12,
                    Nome = "Ginecologia",
                    DataInicio = new DateOnly(2022, 08, 20),
                    Responsavel = "Joana P.",
                    Horario = "08:30 - 16:30",
                    Observacoes = "Consultas ginecológicas e obstétricas",
                    EstabelecimentoId = 3
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
    }
}