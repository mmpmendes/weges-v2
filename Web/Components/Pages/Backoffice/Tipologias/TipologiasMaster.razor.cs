using BlazorBootstrap;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

using Services;

using SharedKernel.DTO;

namespace Web.Components.Pages.Backoffice.Tipologias;

public partial class TipologiasMaster
{
    private IEnumerable<TipologiaDTO>? Tipologias = default!;
    private Grid<TipologiaDTO> TipologiasGrid = default!;
    [Inject]
    public required NavigationManager NavigationManager { get; set; } = default!;
    [Inject]
    public required TipologiaApiService TipologiaApiService { get; set; } = default!;

    private async Task<GridDataProviderResult<TipologiaDTO>> TipologiasDataProvider(GridDataProviderRequest<TipologiaDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        Tipologias = await TipologiaApiService.GetTipologiasAsync(request.CancellationToken);
        if (Tipologias is null)
        {
            return new GridDataProviderResult<TipologiaDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(Tipologias));
    }

    private void NavigateToDetails(long tipologiaId)
    {
        NavigationManager.NavigateTo($"/tipologias/{tipologiaId}");
    }

    private void AddTipologia(MouseEventArgs e)
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
}
