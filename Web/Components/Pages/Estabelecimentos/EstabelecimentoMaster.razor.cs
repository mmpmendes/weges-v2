using BlazorBootstrap;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

using Web.InMemory;

namespace Web.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoMaster
{
    private IList<EstabelecimentoDTO>? Estabelecimentos = default!;
    private Grid<EstabelecimentoDTO> EstabelecimentosGrid = default!;

    [Inject]
    public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required EstabelecimentoService EstabelecimentoService { get; set; }

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

        Estabelecimentos = await EstabelecimentoApiService.GetEstabelecimentosAsync(request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        if (Estabelecimentos is null)
        {
            return new GridDataProviderResult<EstabelecimentoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(Estabelecimentos));
    }

    private void AddEstabelecimento(MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }

    // Note: This method is used to provide the translation for the grid filters
    private async Task<IEnumerable<FilterOperatorInfo>> GridFiltersTranslationProvider()
    {
        var filtersTranslation = new List<FilterOperatorInfo>();

        // number/date/boolean
        filtersTranslation.Add(new("=", "é igual", FilterOperator.Equals));
        filtersTranslation.Add(new("!=", "não é igual", FilterOperator.NotEquals));
        // number/date
        filtersTranslation.Add(new("<", "é menor", FilterOperator.LessThan));
        filtersTranslation.Add(new("<=", "é menor ou igual", FilterOperator.LessThanOrEquals));
        filtersTranslation.Add(new(">", "é maior", FilterOperator.GreaterThan));
        filtersTranslation.Add(new(">=", "é maior ou igual", FilterOperator.GreaterThanOrEquals));
        // string
        filtersTranslation.Add(new("*a*", "contém", FilterOperator.Contains));
        filtersTranslation.Add(new("!*a*", "não contém", FilterOperator.DoesNotContain));
        filtersTranslation.Add(new("a**", "começa com", FilterOperator.StartsWith));
        filtersTranslation.Add(new("**a", "termina com", FilterOperator.EndsWith));
        filtersTranslation.Add(new("=", "é igual", FilterOperator.Equals));
        // common
        filtersTranslation.Add(new("x", "limpar", FilterOperator.Clear));

        return await Task.FromResult(filtersTranslation);
    }

    private Task OnSelectedItemsChanged(HashSet<EstabelecimentoDTO> estabelecimentos)
    {
        EstabelecimentosSelecionados = estabelecimentos is not null && estabelecimentos.Any() ? estabelecimentos : new();
        return Task.CompletedTask;
    }

}
