using System.ComponentModel.DataAnnotations;

namespace weges_v2.SharedKernel.Models;
public class ForgotPasswordModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}
