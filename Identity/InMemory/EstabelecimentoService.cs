using SharedKernel.DTO;

namespace WebApp.InMemory;

public class EstabelecimentoService
{
    public event Action OnEstabelecimentoChanged;

    private EstabelecimentoDTO _selectedEstabelecimento;
    public EstabelecimentoDTO SelectedEstabelecimento
    {
        get => _selectedEstabelecimento;
        set
        {
            _selectedEstabelecimento = value;
            NotifyEstabelecimentoChanged();
        }
    }

    private void NotifyEstabelecimentoChanged()
    {
        OnEstabelecimentoChanged?.Invoke();
    }
}
