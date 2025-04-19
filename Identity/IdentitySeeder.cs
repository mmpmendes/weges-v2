using ApiModel.Models;

using Microsoft.AspNetCore.Identity;

using SharedKernel.Globals;

namespace WebApp;

public static class IdentitySeeder
{
    public static async Task SeedUsersAsync(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<WegesUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure roles exist (optional)
        String[] roles = [
            RoleTypes.Admin.ToString()
            , RoleTypes.User.ToString()];
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Create default admin user
        var adminEmail = configuration["adminEmail"];
        var adminUser = await userManager.FindByNameAsync(adminEmail!);
        if (adminUser == null)
        {
            adminUser = new WegesUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, configuration["adminPassword"]!);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                throw new Exception("Failed to create admin user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}

