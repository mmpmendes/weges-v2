namespace ApiModel.NeoModels;
public class PessoaPessoal
{
    public long Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public Vinculo Vinculo { get; set; }
    public DateOnly DataNascimento { get; set; }
    public DateOnly FichaAptidaoData { get; set; }
    public string ServicoExterno { get; set; } = string.Empty;
    public string CC { get; set; } = string.Empty;
    public DateOnly CCDataValidade { get; set; }
    public string TrabalhadorExposto { get; set; } = string.Empty;

}
