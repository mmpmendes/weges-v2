namespace ApiModel.Models;

public class Estabelecimento : Entity<long>
{
    public required string Denominacao { get; set; }
    public string? Morada { get; set; }
    public DateOnly InicioAtividade { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? TipoPrestador { get; set; }
    public string? Sigla { get; set; }
    public CertificadoERS? CertificadoERS { get; set; }
    public LicencaERS? LicencaERS { get; set; }
}
