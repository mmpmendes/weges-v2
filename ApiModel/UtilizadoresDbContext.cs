using ApiModel.Models;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiModel;
public class UtilizadoresDbContext(DbContextOptions<UtilizadoresDbContext> options) : IdentityDbContext<WegesUser>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("weges_users");

        base.OnModelCreating(modelBuilder);
    }

}
