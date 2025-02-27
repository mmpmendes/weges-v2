namespace ApiModel.Models;

/// <summary>
/// Serviço prestado por um estabelecimento
/// Um estabelecimento pode ter vários serviços
/// </summary>
public class Servico : Entity<long>
{
    public string? Nome { get; set; }
    public DateTime? DataInicio { get; set; }
    public string? Responsavel { get; set; }
    public string? Horario { get; set; }
    public string? Observacoes { get; set; }

    /// <summary>
    /// os serviços têm uma tipologia associada
    /// </summary>
    public long? TipologiaId { get; set; }
    public Tipologia? Tipologia { get; set; }

    /// <summary>
    /// os serviços têm um estabelecimento associado
    /// </summary>
    public long EstabelecimentoId { get; set; }
}
