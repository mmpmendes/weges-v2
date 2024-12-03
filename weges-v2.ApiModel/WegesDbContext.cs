using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel.Models;

namespace weges_v2.ApiModel;

public class WegesDbContext(DbContextOptions<WegesDbContext> options) : DbContext(options)
{

    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<CodCae> CodCaes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            new Entidade { Id = 1, Denominacao = "Teste 1", Morada = "Rua do Teste 1", NifNipc = "123123123", Telefone = "921111111", Email = "emailteste@email.email", Sigla = "TsT1", NrERS = "A-1234", EmailNotificacoesERS = "emailnotificacoes@email.email", EmailNotificacoesGerais = "emailnotificacoes@email.email" },
            new Entidade { Id = 2, Denominacao = "Teste 2", Morada = "Rua do Teste 2", NifNipc = "123123123", Telefone = "921111111", Email = "emailteste@email.email", Sigla = "TsT2", NrERS = "A-1234", EmailNotificacoesERS = "emailnotificacoes@email.email", EmailNotificacoesGerais = "emailnotificacoes@email.email" }
            );
    }
}
