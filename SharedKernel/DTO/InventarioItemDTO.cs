namespace SharedKernel.DTO;
public class InventarioItemDTO
{
    public long Id { get; set; }
    public string NrInventario { get; set; }
    public string Equipamento { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string NrSerie { get; set; }
    public string Localizacao { get; set; }
    public string EmpresaResponsavel { get; set; }
    public string Observavoes { get; set; }
    public bool Estado { get; set; }
}
