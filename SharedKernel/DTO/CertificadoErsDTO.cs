namespace SharedKernel.DTO;
public class CertificadoErsDTO
{
    public long Id { get; set; }
    public string? Periodo { get; set; }
    public string? NrCertificado { get; set; }
    public string? DataSubmissao { get; set; }
    public DateOnly? DataExpiracao { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly? DataExpiracaoTaxa { get; set; }
    public string? DataPagamentoTaxa { get; set; }
    public long EstabelecimentoId { get; set; }
    public FicheiroDTO? Ficheiro { get; set; }
}
