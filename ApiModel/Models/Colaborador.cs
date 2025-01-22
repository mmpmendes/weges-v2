namespace ApiModel.Models;

/// <summary>
/// Colaboradores estão associados a um estabelecimento
/// </summary>
public class Colaborador : Entity<long>
{
    public required string Nome { get; set; }
    public required string NrIdentificacao { get; set; }
    public DateOnly DataNascimento { get; set; }
    public DateOnly InicioAtividade { get; set; }
    public string Cedula { get; set; }
    public string Especialidade { get; set; }
    public bool Estado { get; set; }
    public int TotalHoras { get; set; }
    public string Observacoes { get; set; }

    /// <summary>
    /// os colaboradores têm um serviço associado
    /// </summary>
    public long ServicoId { get; set; }
    public Servico? Servico { get; set; }

    /// <summary>
    /// os colaboradores têm um estabelecimento associado
    /// </summary>
    public long EstabelecimentoId { get; set; }
    public Estabelecimento Estabelecimento { get; set; }

    /// <summary>
    /// os colaboradores têm um tipo associado
    /// </summary>
    public long ColaboradorTipoId { get; set; }
    public ColaboradorTipo ColaboradorTipo { get; set; }

    /// <summary>
    /// os colaboradores têm uma lista de formações associadas
    /// </summary>
    public List<Formacao>? Formacoes { get; set; }
}
