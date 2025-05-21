using ApiModel.NeoModels;

using Microsoft.EntityFrameworkCore;

namespace ApiModel;

public class WegesDbContext(DbContextOptions<WegesDbContext> options) : DbContext(options)
{
    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<DirecaoClinica> DirecoesClinicas { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<CertificadoERS> CertificadosERS { get; set; }
    public DbSet<LicencaERS> LicencasERS { get; set; }

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


    }
}
