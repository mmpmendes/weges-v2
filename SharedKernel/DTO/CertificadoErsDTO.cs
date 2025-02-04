namespace SharedKernel.DTO;
public class CertificadoErsDTO
{
    public long Id { get; set; } = -1;
    public string? Periodo { get; set; }
    public string? NrCertificado { get; set; }
    public string? DataSubmissao { get; set; }
    public DateOnly? DataExpiracao { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly? DataExpiracaoTaxa { get; set; }
    public string? DataPagamentoTaxa { get; set; }
    public long EstabelecimentoId { get; set; }
    public long FicheiroId { get; set; }
    public string? Localizacao { get; set; }
    public string? NomeFicheiro { get; set; }
}
