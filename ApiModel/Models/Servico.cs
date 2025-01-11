namespace ApiModel.Models;
public class Servico : Entity<long>
{
    public string? Nome { get; set; }
    public DateOnly? DataInicio { get; set; }
    public string? Responsavel { get; set; }
    public string? Horario { get; set; }
    public string? Observacoes { get; set; }
    public long EstabelecimentoId { get; set; }
    public long? TipologiaId { get; set; }
    public Tipologia? Tipologia { get; set; }
}
