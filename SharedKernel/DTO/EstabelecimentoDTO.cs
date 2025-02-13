namespace SharedKernel.DTO;

public class EstabelecimentoDTO
{
    public long Id { get; set; }
    public string? Denominacao { get; set; }
    public string? Morada { get; set; }
    public DateOnly InicioAtividade { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public string? TipoPrestador { get; set; }
    public string? Sigla { get; set; }

    public bool someProperty { get; set; } = false;
}
