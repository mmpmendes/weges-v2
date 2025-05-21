namespace ApiModel.NeoModels;
public class DirecaoClinica
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CC { get; set; } = string.Empty;
    public DateOnly CcDataValidade { get; set; }
    public string CedulaProfissional { get; set; } = string.Empty;
    public string Ordem { get; set; } = string.Empty;
    public DateOnly CedulaDataValidade { get; set; }
    public bool DeclaracaoAceitacao { get; set; } = false;
    public string Especialidade { get; set; } = string.Empty;
    public string SubDiretor { get; set; } = string.Empty;
    public string SubDiretorCC { get; set; } = string.Empty;
    public DateOnly SubDiretorCcDataValidade { get; set; }
    public string SubDiretorCedulaProfissional { get; set; } = string.Empty;
    public string SubDiretorOrdem { get; set; } = string.Empty;
    public DateOnly SubDiretorCedulaDataValidade { get; set; }
}
