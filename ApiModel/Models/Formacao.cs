namespace ApiModel.Models;

/// <summary>
/// Utilizadores podem ter formações
/// Varios colaboradores podem ter a mesma formação
/// </summary>
public class Formacao : Entity<long>
{
    public required string Nome { get; set; }
    public int HorasFormacao { get; set; }
    public DateOnly Data { get; set; }
    public string? Observacoes { get; set; }
}
