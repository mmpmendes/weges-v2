namespace SharedKernel.DTO;
public class ManutencaoDTO
{
    public long Id { get; set; }
    public string NrEquipamento { get; set; }
    public DateOnly DataManutencao { get; set; }
    public DateOnly ProximaManutencao { get; set; }
    public string Observacoes { get; set; }
}
