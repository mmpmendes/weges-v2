namespace weges_v2.SharedKernel.Models;
public class ConfirmationModel
{
    public string UserId { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string ChangedEmail { get; set; } = string.Empty;
}
