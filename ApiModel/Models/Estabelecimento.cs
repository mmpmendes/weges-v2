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
    public Anexo? CartaoNIPC { get; set; }
    public Anexo? Alvara { get; set; }
    public Anexo? MedidaANPC { get; set; }
    public Anexo? ParecerANPC { get; set; }
    public Anexo? ListaVerificacao { get; set; }
    public Anexo? FicheirosAnexar { get; set; }
    public Anexo? DireitosDeveres { get; set; }
    public Anexo? LicenciamentoRegistoLegal { get; set; }
}
