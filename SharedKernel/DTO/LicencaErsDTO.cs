namespace SharedKernel.DTO;
public class LicencaErsDTO
{
    public long Id { get; set; }
    public string? Periodo { get; set; }
    public string? NrLicenca { get; set; }
    public string? DataSubmissao { get; set; }
    public string? Observacoes { get; set; }
    public long EstabelecimentoId { get; set; }
    public long FicheiroId { get; set; }
    public required string Localizacao { get; set; }
    public required string NomeFicheiro { get; set; }
}
