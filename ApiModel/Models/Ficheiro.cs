namespace ApiModel.Models;
public class Ficheiro : Entity<long>
{
    public string? Nome { get; set; }
    public string? NomeOriginal { get; set; }
    public string? Tipo { get; set; }
    public string? Url { get; set; }
}
