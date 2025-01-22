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

        modelBuilder.Entity<Estabelecimento>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<DirecaoClinica>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<Servico>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<Ficheiro>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
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
        modelBuilder.Entity<CertificadoERS>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
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
        modelBuilder.Entity<ColaboradorTipo>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
        });
        modelBuilder.Entity<AnexoTipo>(ent =>
        {
            //auto increment Id
            ent.Property(e => e.Id).ValueGeneratedOnAdd();
            ent.Property(e => e.CreatedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.ModifiedBy).HasDefaultValue("system-usr");
            ent.Property(e => e.Modified).HasDefaultValueSql("NOW()");
            ent.Property(e => e.Created).HasDefaultValueSql("NOW()");
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

        modelBuilder.Entity<Estabelecimento>(entity =>
        {
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

            entity.HasMany(e => e.CartoesNipc)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoCartoesNipc", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoCartoesNipc");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.Alvaras)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoAlvaras", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoAlvaras");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.MedidasANPC)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoMedidasANPC", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoMedidasANPC");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.ParecerANPC)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoParecerANPC", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoParecerANPC");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.ListaVerificacao)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoListaVerificacao", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoListaVerificacao");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.FicheirosAnexar)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoFicheirosAnexar", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoFicheirosAnexar");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.DireitosDeveres)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoDireitosDeveres", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoDireitosDeveres");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });

            entity.HasMany(e => e.LicenciamentoRegistoLegal)
                .WithMany(entity => entity.Estabelecimentos)
                .UsingEntity<Dictionary<string, object>>(
                "EstabelecimentoLicenciamentoRegistoLegal", // Name of the join table
                j => j.HasOne<Anexo>().WithMany().HasForeignKey("AnexoId"),
                j => j.HasOne<Estabelecimento>().WithMany().HasForeignKey("EstabelecimentoId"),
                j =>
                {
                    j.ToTable("EstabelecimentoLicenciamentoRegistoLegal");
                    j.HasKey("EstabelecimentoId", "AnexoId");
                });
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

        modelBuilder.Entity<LicencaERS>()
            .HasOne(c => c.Ficheiro)
            .WithMany()
            .HasForeignKey(c => c.FicheiroId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<CertificadoERS>()
            .HasOne(c => c.Ficheiro)
            .WithMany()
            .HasForeignKey(c => c.FicheiroId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<DirecaoClinica>()
            .HasOne(d => d.Tipologia)
            .WithMany()
            .HasForeignKey(d => d.TipologiaId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Servico>()
            .HasOne(s => s.Tipologia)
            .WithMany()
            .HasForeignKey(s => s.TipologiaId)
            .OnDelete(DeleteBehavior.SetNull);

        // Configure Ficheiro
        modelBuilder.Entity<Ficheiro>(entity =>
        {
            entity.Property(f => f.Nome).HasMaxLength(255);
            entity.Property(f => f.Localizacao).HasMaxLength(512);
            entity.Property(f => f.Tipo).HasMaxLength(100);
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

        // Configure AnexoTipo
        modelBuilder.Entity<AnexoTipo>(entity =>
        {
            entity.Property(at => at.Tipo).HasMaxLength(100);
        });
    }
}
