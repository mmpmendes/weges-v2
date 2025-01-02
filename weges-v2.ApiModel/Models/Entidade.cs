namespace ApiModel.Models;
public class Entidade : Entity<long>
{
    public string? Denominacao { get; set; }
    public string? Morada { get; set; }
    public required string NifNipc { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Sigla { get; set; }
    public string? NrERS { get; set; }
    public string? EmailNotificacoesERS { get; set; }
    public string? EmailNotificacoesGerais { get; set; }
    public List<CodCae>? CodCaes { get; set; }
}
