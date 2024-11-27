namespace weges_v2.ApiService.DTO;

public class EntidadeDTO
{
    public long Id { get; set; }
    public string? Denominacao { get; set; }
    public string? Morada { get; set; }
    public required string NifNipc { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public string? Sigla { get; set; }
    public int NrERS { get; set; }
    public string? EmailNotificacoesERS { get; set; }
    public string? EmailNotificacoesGerais { get; set; }
    public string? CodCaeId { get; set; }
    //public CodCaeDTO? CodCae { get; set; }
    //public IEnumerable<CodCaeDTO>? CaesSecundarios { get; set; }
}
