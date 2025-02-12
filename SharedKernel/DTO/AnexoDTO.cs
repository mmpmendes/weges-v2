namespace SharedKernel.DTO;
public class AnexoDTO
{
    public long Id { get; set; }
    public string? Nome { get; set; }
    public DateOnly Submetido { get; set; }
    public long FicheiroId { get; set; }
    public string? Observacoes { get; set; }

    public long EstabelecimentoId { get; set; }
}
