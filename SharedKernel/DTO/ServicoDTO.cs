namespace SharedKernel.DTO;
public class ServicoDTO
{
    public long Id { get; set; }
    public string? Nome { get; set; }
    public DateTime? DataInicio { get; set; }
    public string? Responsavel { get; set; }
    public string? Horario { get; set; }
    public string? Observacoes { get; set; }
    public long TipologiaId { get; set; }
    public string? Tipologia { get; set; }
    public long EstabelecimentoId { get; set; }
}
