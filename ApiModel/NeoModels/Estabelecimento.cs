namespace ApiModel.NeoModels;
public class Estabelecimento
{
    public long Id { get; set; }
    public string Sigla { get; set; } = string.Empty;
    public string Denominacao { get; set; } = string.Empty;
    public DateOnly DataInicioAtividade { get; set; }
    public string Morada { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string TipoPrestador { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;

    public string CodigoApa { get; set; } = string.Empty;
    public string AutorizacaoInfarmed { get; set; } = string.Empty;

    public DirecaoClinica? DirecaoClinica { get; set; }

}
