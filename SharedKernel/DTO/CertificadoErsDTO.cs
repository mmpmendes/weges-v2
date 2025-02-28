namespace SharedKernel.DTO;
public class CertificadoErsDTO
{
    public long Id { get; set; }
    public string? Periodo { get; set; }
    public string? NrCertificado { get; set; }
    public string? DataSubmissao { get; set; }
    public DateTime? DataExpiracao { get; set; }
    public string? Observacoes { get; set; }
    public DateTime? DataExpiracaoTaxa { get; set; }
    public DateTime? DataPagamentoTaxa { get; set; }
    public long EstabelecimentoId { get; set; }
    public long FicheiroId { get; set; }
}
