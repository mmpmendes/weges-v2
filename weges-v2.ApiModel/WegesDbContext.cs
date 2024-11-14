using Microsoft.EntityFrameworkCore;

namespace weges_v2.ApiModel;

public class WegesDbContext(DbContextOptions<WegesDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public DbSet<Estabelecimento> estabelecimentos { get; set; }
}
