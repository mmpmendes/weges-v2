using BlazorBootstrap;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;
using SharedKernel.DTO;

namespace Web.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoMaster
{
    private IList<EstabelecimentoDTO>? Estabelecimentos = default!;
    private Grid<EstabelecimentoDTO> EstabelecimentosGrid = default!;

    [Inject]
    public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Estabelecimentos = await EstabelecimentoApiService.GetEstabelecimentosAsync();
    }

    private void NavigateToDetails(long estabelecimentoId)
    {
        NavigationManager.NavigateTo($"/estabelecimento/{estabelecimentoId}");
    }

    private async Task<GridDataProviderResult<EstabelecimentoDTO>> EstabelecimentosDataProvider(GridDataProviderRequest<EstabelecimentoDTO> request)
    {
        if (Estabelecimentos is null)
        {
            Estabelecimentos = await EstabelecimentoApiService.GetEstabelecimentosAsync();
            if (Estabelecimentos is not null)
                return await Task.FromResult(request.ApplyTo(Estabelecimentos));
        }
        return new GridDataProviderResult<EstabelecimentoDTO>()
        {
            Data = [],
            TotalCount = 0
        };
    }

    private void AddEstabelecimento(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }
}
