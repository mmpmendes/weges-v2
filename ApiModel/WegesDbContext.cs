using ApiModel.Models;

using Microsoft.EntityFrameworkCore;

namespace ApiModel;

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

        base.OnModelCreating(modelBuilder);
    }
}
