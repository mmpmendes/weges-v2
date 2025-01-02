using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel.Models;

namespace weges_v2.ApiModel;

public class WegesDbContext(DbContextOptions<WegesDbContext> options) : DbContext(options)
{
    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<CodCae> CodCaes { get; set; }
    public DbSet<DirecaoClinica> DirecoesClinicas { get; set; }
    public DbSet<Servico> Servicos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.HasDefaultSchema("weges");

        modelBuilder.Entity<Entidade>(entidade =>
        {
            //auto increment Id
            entidade.Property(e => e.Id).ValueGeneratedOnAdd();
            entidade.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            entidade.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            entidade.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            entidade.Property(e => e.Created).HasDefaultValueSql("NOW()");
            entidade.Property(e => e.Denominacao).HasMaxLength(200);
            entidade.Property(e => e.Morada).HasMaxLength(200);
            entidade.Property(e => e.NifNipc).HasMaxLength(9);
            entidade.Property(e => e.Telefone).HasMaxLength(9);
            entidade.Property(e => e.Email).HasMaxLength(50);
            entidade.Property(e => e.Sigla).HasMaxLength(8);
            entidade.Property(e => e.EmailNotificacoesGerais).HasMaxLength(50);
            entidade.Property(e => e.EmailNotificacoesERS).HasMaxLength(50);
        });

        modelBuilder.Entity<Estabelecimento>(estabelecimento =>
        {
            //auto increment Id
            estabelecimento.Property(e => e.Id).ValueGeneratedOnAdd();
            estabelecimento.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            estabelecimento.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            estabelecimento.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            estabelecimento.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<DirecaoClinica>(dirclinica =>
        {
            //auto increment Id
            dirclinica.Property(e => e.Id).ValueGeneratedOnAdd();
            dirclinica.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            dirclinica.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            dirclinica.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            dirclinica.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<Servico>(servico =>
        {
            //auto increment Id
            servico.Property(e => e.Id).ValueGeneratedOnAdd();
            servico.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            servico.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            servico.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            servico.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });

        modelBuilder.Entity<Entidade>().HasData(
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
            });

        modelBuilder.Entity<Estabelecimento>().HasData(
            new Estabelecimento
            {
                Id = 1,
                Denominacao = "Estabelecimento 1",
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
            });

        modelBuilder.Entity<DirecaoClinica>().HasData(
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
            });

        modelBuilder.Entity<Servico>().HasData(
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
            });


        base.OnModelCreating(modelBuilder);
    }
}
