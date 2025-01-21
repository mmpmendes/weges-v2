namespace SharedKernel.DTO;
public class FicheirosLicenciamentoDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public DateOnly Submetido { get; set; }
    public string Observacoes { get; set; }
}
