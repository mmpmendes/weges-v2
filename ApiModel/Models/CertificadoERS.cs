namespace ApiModel.Models;
public class CertificadoERS : Entity<long>
{
    public string? Periodo { get; set; }
    public string? NrCertificado { get; set; }
    public DateOnly? DataSubmissao { get; set; }
    public DateOnly? DataExpiracao { get; set; }
    public string? Observacoes { get; set; }
    public DateOnly? DataExpiracaoTaxa { get; set; }
    public DateOnly? DataPagamentoTaxa { get; set; }
    public long EstabelecimentoId { get; set; }
    public long FicheiroId { get; set; }
    public string? Localizacao { get; set; }
    public string? NomeFicheiro { get; set; }
}
