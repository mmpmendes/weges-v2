using SharedKernel.DTO;

namespace Identity.InMemory;

public class UtilizadorService
{
    public event Action OnUtilizadorChanged;

    private WegesUserDTO _selectedUtilizador;
    public WegesUserDTO SelectedEstabelecimento
    {
        get => _selectedUtilizador;
        set
        {
            _selectedUtilizador = value;
            NotifyEstabelecimentoChanged();
        }
    }

    private void NotifyEstabelecimentoChanged()
    {
        OnUtilizadorChanged?.Invoke();
    }
}
