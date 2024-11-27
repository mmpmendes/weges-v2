namespace weges_v2.ApiModel.Models;
public class CodCae : Entity<long>
{
    public string Codigo { get; set; } = string.Empty;
    public string Designacao { get; set; } = string.Empty;
    public List<Entidade>? Entidades { get; set; }
}
