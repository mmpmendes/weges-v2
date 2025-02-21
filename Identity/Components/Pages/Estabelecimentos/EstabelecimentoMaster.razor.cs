using Identity.InMemory;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoMaster
{
    private IList<EstabelecimentoDTO>? Estabelecimentos = default!;
    private MudDataGrid<EstabelecimentoDTO> EstabelecimentosGrid = default!;
    private string searchString1 = "";

    [Inject] public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }

    [Inject] public required NavigationManager NavigationManager { get; set; }

    [Inject] public required EstabelecimentoService EstabelecimentoService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var listEstabelecimentosDTO = await EstabelecimentoApiService.GetEstabelecimentosFiltradosAsync();

        Estabelecimentos = listEstabelecimentosDTO?.Estabelecimentos;
    }

    // Note: This method is used to navigate to the details page
    private void NavigateToDetails(long estabelecimentoId)
    {
        NavigationManager.NavigateTo($"/estabelecimentos/{estabelecimentoId}");
    }

    // Note: This method is used to provide the data for the grid
    private async Task<GridData<EstabelecimentoDTO>> EstabelecimentosDataProvider(GridState<EstabelecimentoDTO> state)
    {
        ListEstabelecimentosDTO? response = await EstabelecimentoApiService.GetEstabelecimentosFiltradosAsync(
            filters: state.FilterDefinitions,
            pageNumber: state.Page,
            pageSize: state.PageSize,
            sortString: state.SortDefinitions.FirstOrDefault()?.ToString()!);

        if (response is null)
        {
            Estabelecimentos = [];
            return new GridData<EstabelecimentoDTO>()
            {
                TotalItems = 0,
                Items = []
            };
        }
        else
        {
            Estabelecimentos = response.Estabelecimentos;
            return new GridData<EstabelecimentoDTO>()
            {
                TotalItems = response.TotalCount,
                Items = response.Estabelecimentos ?? []
            };
        }
    }

    private void AddEstabelecimento(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }

    private void SeleccionaEstabelecimento(long estabelecimentoId)
    {
        EstabelecimentoService.SelectedEstabelecimento = Estabelecimentos!.First(e => e.Id == estabelecimentoId);
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
