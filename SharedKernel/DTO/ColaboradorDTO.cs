namespace SharedKernel.DTO;
public class ColaboradorDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public string NrIdentificacao { get; set; }
    public DateOnly DataNascimento { get; set; }
    public DateOnly InicioAtividade { get; set; }
    public string Cedula { get; set; }
    public string Especialidade { get; set; }
    public bool Estado { get; set; }
    public int TotalHoras { get; set; }
    public string Observacoes { get; set; }
}
