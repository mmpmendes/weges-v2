namespace ApiModel.NeoModels;
public class LicencaERS
{
    public long Id { get; set; }
    public string Licenca { get; set; } = string.Empty;
    public DateOnly DataValidade { get; set; }
    public string Ficheiro { get; set; } = string.Empty;

    public long EstabelecimentoId { get; set; }
}
