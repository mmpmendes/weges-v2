namespace Services;
public class EmailConfiguracoes
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool UseSSL { get; set; }
    public string DefaultSubject { get; set; } = string.Empty;
}