using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoMaster
{
    private IList<EstabelecimentoDTO>? Estabelecimentos = default!;
    private Grid<EstabelecimentoDTO> EstabelecimentosGrid = default!;
    private CheckboxInput checkId;

    [Inject] public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }

    [Inject] public required NavigationManager NavigationManager { get; set; }

    [Inject] public required EstabelecimentoService EstabelecimentoService { get; set; }

    private HashSet<EstabelecimentoDTO> EstabelecimentosSelecionados = new();

    // Note: This method is used to navigate to the details page
    private void NavigateToDetails(long estabelecimentoId)
    {
        NavigationManager.NavigateTo($"/estabelecimentos/{estabelecimentoId}");
    }

    // Note: This method is used to provide the data for the grid
    private async Task<GridDataProviderResult<EstabelecimentoDTO>> EstabelecimentosDataProvider(GridDataProviderRequest<EstabelecimentoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        //Estabelecimentos = await EstabelecimentoApiService.GetEstabelecimentosFiltradosAsync(request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        var response = await EstabelecimentoApiService.GetEstabelecimentosFiltradosAsync(request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);

        Estabelecimentos = [];

        if (response is null)
        {
            return new GridDataProviderResult<EstabelecimentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }
        else
        {
            Estabelecimentos = response.Estabelecimentos;
            return new GridDataProviderResult<EstabelecimentoDTO>()
            {
                Data = response.Estabelecimentos,
                TotalCount = response.TotalCount
            };
        }
    }

    private void AddEstabelecimento(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }

    private void SeleccionaEstabelecimento(long estabelecimentoId)
    {
        EstabelecimentoService.SelectedEstabelecimento = Estabelecimentos.First(e => e.Id == estabelecimentoId);
    }

    private bool IsEstabelecimentoSelected(long estabelecimentoId)
    {
        return EstabelecimentoService.SelectedEstabelecimento?.Id == estabelecimentoId;
    }
    //private async Task DoSomething(bool value, EstabelecimentoDTO estabelecimento)
    //{
    //    Console.WriteLine("Save - " + estabelecimento.someProperty);

    //    estabelecimento.someProperty = value;
    //}
}
