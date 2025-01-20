using Microsoft.AspNetCore.Identity;

namespace ApiModel.Models;
public class WegesUser : IdentityUser
{
    [PersonalData]
    public string? FullName { get; set; }
}
