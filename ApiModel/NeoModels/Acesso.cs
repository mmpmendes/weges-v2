namespace ApiModel.NeoModels;
public class Acesso
{
    public long Id { get; set; }
    public AcessoTipo AcessoTipo { get; set; }
    public string Utilizador { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
