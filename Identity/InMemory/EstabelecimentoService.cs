using SharedKernel.DTO;

namespace Identity.InMemory;

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
            NotifyEstabelecimentoChanged().GetAwaiter();
        }
    }

    private async Task NotifyEstabelecimentoChanged()
    {
        OnEstabelecimentoChanged?.Invoke();
    }
}
