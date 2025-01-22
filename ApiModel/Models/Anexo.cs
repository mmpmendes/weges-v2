namespace ApiModel.Models;
public class Anexo : Entity<long>
{
    public required string Nome { get; set; }
    public DateOnly Submetido { get; set; }
    public string? Observacoes { get; set; }
    public long FicheiroId { get; set; }
    public Ficheiro Ficheiro { get; set; }

    public long AnexoTipoId { get; set; }
    public AnexoTipo AnexoTipo { get; set; }

    public ICollection<Estabelecimento> Estabelecimentos { get; set; } = new List<Estabelecimento>();
}
