namespace ApiModel.Models;
public class LicencaERS : Entity<long>
{
    public string? Periodo { get; set; }
    public string? NrLicenca { get; set; }
    public DateOnly? DataSubmissao { get; set; }
    public string? Observacoes { get; set; }
    public long EstabelecimentoId { get; set; }
    public long FicheiroId { get; set; }
    public required string Localizacao { get; set; }
    public required string NomeFicheiro { get; set; }
}
