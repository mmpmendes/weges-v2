namespace ApiModel.NeoModels;
public class Entidade
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public List<Acesso>? Acessos { get; set; }
    public List<Mensagem>? Mensagens { get; set; }
}
