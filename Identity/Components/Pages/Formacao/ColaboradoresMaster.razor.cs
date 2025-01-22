using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Formacao;

public partial class ColaboradoresMaster
{
    private IList<ColaboradorDTO>? ColaboradoresItems = default!;
    private Grid<ColaboradorDTO> ColaboradoresGrid = default!;

    [Inject] public EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] public EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    // Note: This method is used to provide the data for the grid
    private async Task<GridDataProviderResult<ColaboradorDTO>> ColaboradoresDataProvider(GridDataProviderRequest<ColaboradorDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        try
        {
            ColaboradoresItems = await EstabelecimentoApiService.GetEstabelecimentoColaboradoresAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (ColaboradoresItems is null)
        {
            return new GridDataProviderResult<ColaboradorDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(ColaboradoresItems));
    }
}
