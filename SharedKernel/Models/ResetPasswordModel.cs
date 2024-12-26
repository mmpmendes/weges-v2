namespace weges_v2.SharedKernel.Models;
public class ResetPasswordModel
{
    public string NewPassword { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
}
