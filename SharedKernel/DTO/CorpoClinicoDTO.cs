namespace SharedKernel.DTO;
public class CorpoClinicoDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Cedula { get; set; }
    public bool Estado { get; set; }
    public DateOnly DataSaida { get; set; }
    public string Servico { get; set; }
}
