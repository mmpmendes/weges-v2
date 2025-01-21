using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Formacao;

public partial class FormacaoMaster
{
    private IList<FormacaoDTO>? FormacaoItems = default!;
    private Grid<FormacaoDTO> FormacaoGrid = default!;

    [Inject] public EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] public EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    // Note: This method is used to provide the data for the grid
    private async Task<GridDataProviderResult<FormacaoDTO>> FormacaoDataProvider(GridDataProviderRequest<FormacaoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        FormacaoItems = await EstabelecimentoApiService.GetEstabelecimentoFormacaoAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        if (FormacaoItems is null)
        {
            return new GridDataProviderResult<FormacaoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(FormacaoItems));
    }
}
