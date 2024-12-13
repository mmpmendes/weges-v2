namespace weges_v2.SharedKernel.DTO;

public class EstabelecimentoDTO
{
    public required string Denominacao { get; set; }
    public string? Morada { get; set; }
    public DateOnly InicioAtividade { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? TipoPrestador { get; set; }
    public string? Sigla { get; set; }
}
