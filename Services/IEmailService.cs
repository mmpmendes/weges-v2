namespace Services;
public interface IEmailService
{
    Task<bool> EnviarEmail(List<string> paras
        , Dictionary<string, string> placeHolders
        , string templatePath
        , List<string>? ccs = null
        , List<string>? bccs = null);
}