namespace ApiModel.NeoModels;
public class CertificadoERS
{
    public long Id { get; set; }
    public string Certificado { get; set; } = string.Empty;
    public DateOnly DataValidade { get; set; }
    public string Ficheiro { get; set; } = string.Empty;

    public long EstabelecimentoId { get; set; }
}
