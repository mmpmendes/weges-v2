namespace ApiModel.Models;
public class CertificadoERS : Entity<long>
{
    public string? Periodo { get; set; }
    public string? NrCertificado { get; set; }
    public DateTime? DataSubmissao { get; set; }
    public DateTime? DataExpiracao { get; set; }
    public string? Observacoes { get; set; }
    public DateTime? DataExpiracaoTaxa { get; set; }
    public DateTime? DataPagamentoTaxa { get; set; }

    // One-to-One relationship with Estabelecimento
    public long EstabelecimentoId { get; set; }
    public Estabelecimento? Estabelecimento { get; set; }

    // Many-to-One relationship with Ficheiro
    public long? FicheiroId { get; set; }
    public Ficheiro? Ficheiro { get; set; }
}
