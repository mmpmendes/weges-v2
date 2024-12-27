using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel.Models;

namespace weges_v2.ApiModel;
public class UtilizadoresDbContext(DbContextOptions<UtilizadoresDbContext> options) : IdentityDbContext<WegesUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("weges_users");

        base.OnModelCreating(modelBuilder);
    }

}
