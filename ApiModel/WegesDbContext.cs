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
    public DbSet<Ficheiro> Ficheiros { get; set; }
    public DbSet<CertificadoERS> CertificadosERS { get; set; }
    public DbSet<LicencaERS> LicencasERS { get; set; }
    public DbSet<Tipologia> Tipologias { get; set; }
    public DbSet<Anexo> Anexos { get; set; }
    public DbSet<AnexoTipo> AnexoTipos { get; set; }
    public DbSet<Colaborador> Colaboradores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("weges");

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetColumnType("timestamp without time zone");
                }
            }
        }

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

        modelBuilder.Entity<Estabelecimento>(entity =>
        {
            //auto increment Id
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            entity.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            entity.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            entity.Property(e => e.Created).HasDefaultValueSql("NOW()");

            entity.Property(e => e.Denominacao).HasMaxLength(255);
            entity.Property(e => e.Morada).HasMaxLength(512);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Telefone).HasMaxLength(50);
            entity.Property(e => e.TipoPrestador).HasMaxLength(100);
            entity.Property(e => e.Sigla).HasMaxLength(50);

            entity.HasOne(e => e.CertificadoERS)
                 .WithOne(c => c.Estabelecimento)
                 .HasForeignKey<CertificadoERS>(c => c.EstabelecimentoId)
                 .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(l => l.LicencaERS)
                .WithOne(c => c.Estabelecimento)
                .HasForeignKey<LicencaERS>(c => c.EstabelecimentoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.CartaoNipc)
                 .WithOne()
                 .HasForeignKey<Anexo>(a => a.Id)
                 .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Alvara)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.MedidaAnpc)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.ParecerAnpc)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.ListaVerificacao)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.FicheirosAnexar)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.DireitosDeveres)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.LicenciamentoRegistoLegal)
                .WithOne()
                .HasForeignKey<Anexo>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });
        modelBuilder.Entity<LicencaERS>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<LicencaERS>()
            .HasOne(c => c.Ficheiro)
            .WithMany()
            .HasForeignKey(c => c.FicheiroId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CertificadoERS>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<CertificadoERS>()
            .HasOne(c => c.Ficheiro)
            .WithMany()
            .HasForeignKey(c => c.FicheiroId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<DirecaoClinica>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<DirecaoClinica>()
            .HasOne(d => d.Tipologia)
            .WithMany()
            .HasForeignKey(d => d.TipologiaId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Servico>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<Servico>()
            .HasOne(s => s.Tipologia)
            .WithMany()
            .HasForeignKey(s => s.TipologiaId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Ficheiro>(entity =>
        {
            //auto increment Id
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            entity.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            entity.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            entity.Property(e => e.Created).HasDefaultValueSql("NOW()");

            entity.Property(f => f.Nome).HasMaxLength(255);
            entity.Property(f => f.Tipo).HasMaxLength(100);
        });

        modelBuilder.Entity<Colaborador>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<Colaborador>()
            .HasOne(c => c.ColaboradorTipo)
            .WithMany()
            .HasForeignKey(c => c.ColaboradorTipoId)
            .OnDelete(DeleteBehavior.SetNull);
        modelBuilder.Entity<Colaborador>()
            .HasOne(c => c.Estabelecimento)
            .WithMany()
            .HasForeignKey(c => c.EstabelecimentoId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<ColaboradorTipo>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<AnexoTipo>(entity =>
        {
            //auto increment Id
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            entity.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            entity.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            entity.Property(e => e.Created).HasDefaultValueSql("NOW()");
            entity.Property(at => at.Tipo).HasMaxLength(100);
        });
        modelBuilder.Entity<Formacao>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });

        // Configure Anexo
        modelBuilder.Entity<Anexo>(entity =>
        {
            entity.Property(a => a.Nome).HasMaxLength(255);
            entity.Property(a => a.Observacoes).HasMaxLength(1000);

            entity.HasOne(a => a.Ficheiro)
                .WithMany()
                .HasForeignKey(a => a.FicheiroId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(a => a.AnexoTipo)
                .WithMany()
                .HasForeignKey(a => a.AnexoTipoId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
