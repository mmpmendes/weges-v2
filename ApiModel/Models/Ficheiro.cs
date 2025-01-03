namespace ApiModel.Models;
public class Ficheiro : Entity<long>
{
    public string? Nome { get; set; }
    public string? Localizacao { get; set; }
    public string? Tipo { get; set; }
}
