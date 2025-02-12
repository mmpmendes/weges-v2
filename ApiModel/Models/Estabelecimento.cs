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

    public long? CartaoNipcId { get; set; }
    public Anexo? CartaoNipc { get; set; }

    public long? AlvaraId { get; set; }
    public Anexo? Alvara { get; set; }

    public long? MedidaAnpcId { get; set; }
    public Anexo? MedidaAnpc { get; set; }

    public long? ParecerAnpcId { get; set; }
    public Anexo? ParecerAnpc { get; set; }

    public long? ListaVerificacaoId { get; set; }
    public Anexo? ListaVerificacao { get; set; }

    public long? FicheirosAnexarId { get; set; }
    public Anexo? FicheirosAnexar { get; set; }

    public long? DireitosDeveresId { get; set; }
    public Anexo? DireitosDeveres { get; set; }

    public long? LicenciamentoRegistoLegalId { get; set; }
    public Anexo? LicenciamentoRegistoLegal { get; set; }
}
