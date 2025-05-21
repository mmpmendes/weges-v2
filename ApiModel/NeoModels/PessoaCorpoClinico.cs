namespace ApiModel.NeoModels;
public class PessoaCorpoClinico
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string EntEmissoraCedula { get; set; } = string.Empty;
    public string Cedula { get; set; } = string.Empty;
    public DateOnly CedulaDataValidade { get; set; }
    public Vinculo Vinculo { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Tecnico { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public bool Responsavel { get; set; }
    public DateOnly FichaAptidaoData { get; set; }
    public string ServicoExterno { get; set; } = string.Empty;
    public string SeguroRC { get; set; } = string.Empty;
    public DateOnly SeguroRcValidade { get; set; }
    public string CC { get; set; } = string.Empty;
    public DateOnly CCDataValidade { get; set; }
    public bool TrabalhadorExposto { get; set; }

    public Servico? Servico { get; set; }
}
