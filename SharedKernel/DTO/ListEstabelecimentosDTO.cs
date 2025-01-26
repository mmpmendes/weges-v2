namespace SharedKernel.DTO;
public class ListEstabelecimentosDTO
{
    public IList<EstabelecimentoDTO>? Estabelecimentos { get; set; }
    public int TotalCount { get; set; }
}
