using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Web.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoDetails
{
    [Parameter]
    public long Id { get; set; }

    [Inject]
    public required DirecaoClinicaApiService DirecaoClinicaApiService { get; set; }
    private IList<DirecaoClinicaDTO>? DirecoesClinicas = default!;

    [Inject]
    public required ServicosApiService ServicosApiService { get; set; }
    private IList<ServicoDTO>? Servicos = default!;

    private async Task<GridDataProviderResult<DirecaoClinicaDTO>> DirecoesClinicasDataProvider(GridDataProviderRequest<DirecaoClinicaDTO> request)
    {
        if (DirecoesClinicas is null)
        {
            DirecoesClinicas = await DirecaoClinicaApiService.GetDirecoesClinicasAsync();
            if (DirecoesClinicas is not null)
                return await Task.FromResult(request.ApplyTo(DirecoesClinicas));
        }
        return new GridDataProviderResult<DirecaoClinicaDTO>()
        {
            Data = [],
            TotalCount = 0
        };
    }

    private async Task<GridDataProviderResult<ServicoDTO>> ServicosDataProvider(GridDataProviderRequest<ServicoDTO> request)
    {
        if (Servicos is null)
        {
            Servicos = await ServicosApiService.GetServicosAsync();
            if (Servicos is not null)
                return await Task.FromResult(request.ApplyTo(Servicos));
        }
        return new GridDataProviderResult<ServicoDTO>()
        {
            Data = [],
            TotalCount = 0
        };
    }
}
