namespace SharedKernel.Models;
public class ValidationDetails
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Detail { get; set; } = string.Empty;
    public string Instance { get; set; } = string.Empty;
    public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
    public string AdditionalProp1 { get; set; } = string.Empty;
    public string AdditionalProp2 { get; set; } = string.Empty;
    public string AdditionalProp3 { get; set; } = string.Empty;
}
