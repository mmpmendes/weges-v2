using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel.Models;

namespace weges_v2.ApiModel;

public class WegesDbContext(DbContextOptions<WegesDbContext> options) : DbContext(options)
{
    public DbSet<Estabelecimento> Estabelecimentos { get; set; }
    public DbSet<Entidade> Entidades { get; set; }
    public DbSet<CodCae> CodCaes { get; set; }
}
