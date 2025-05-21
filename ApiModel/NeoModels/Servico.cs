namespace ApiModel.NeoModels;
public class Servico
{
    public long Id { get; set; }
    public string Denominacao { get; set; } = string.Empty;
    public string Diretor { get; set; } = string.Empty;
    public string DiretorCC { get; set; } = string.Empty;
    public DateOnly DiretorCcDataValidade { get; set; }
    public string DiretorCedulaProfissional { get; set; } = string.Empty;
    public string DiretorOrdem { get; set; } = string.Empty;
    public string DeclaracaoAceitacao { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public string Horario { get; set; } = string.Empty;

    public CertificadoERS? Certificado { get; set; }
    public LicencaERS? Licenca { get; set; }

    public long EstabelecimentoId { get; set; }
}
