using Microsoft.AspNetCore.Identity;
using ApiModel.Models;

namespace Identity.Components.Account;

internal sealed class IdentityUserAccessor(UserManager<WegesUser> userManager, IdentityRedirectManager redirectManager)
{
    public async Task<WegesUser> GetRequiredUserAsync(HttpContext context)
    {
        var user = await userManager.GetUserAsync(context.User);

        if (user is null)
        {
            redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
        }

        return user;
    }
}
