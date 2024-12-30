using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel.Models;

namespace weges_v2.ApiModel;

public class WegesDbContext : DbContext
{

    public WegesDbContext(DbContextOptions<WegesDbContext> options) : base(options)
    {

    }

    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<CodCae> CodCaes { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}
