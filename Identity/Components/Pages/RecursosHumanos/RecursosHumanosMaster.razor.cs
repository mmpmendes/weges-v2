using BlazorBootstrap;

using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.RecursosHumanos;

public partial class RecursosHumanosMaster
{
    private IList<ServicoDTO>? Servicos = default!;
    private Grid<ServicoDTO> ServicosGrid = default!;

    private IList<CorpoClinicoDTO>? CorpoClinico = default!;
    private Grid<CorpoClinicoDTO> CorpoClinicoGrid = default!;

    [Inject]
    public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required EstabelecimentoService EstabelecimentoService { get; set; }

    // Note: This method is used to provide the data for the grid
    private async Task<GridDataProviderResult<ServicoDTO>> ServicosDataProvider(GridDataProviderRequest<ServicoDTO> request)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        if (request.Sorting is not null && request.Sorting.Any())
        {
            // Note: Multi column sorting is not supported at this moment
            sortString = request.Sorting.FirstOrDefault()!.SortString;
            sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        }

        Servicos = await EstabelecimentoApiService.GetEstabelecimentoServicosAsync(EstabelecimentoService.SelectedEstabelecimento.Id);
        if (Servicos is null)
        {
            return new GridDataProviderResult<ServicoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }

        return await Task.FromResult(request.ApplyTo(Servicos));
    }

    // Note: This method is used to provide the data for the grid
    private async Task<GridDataProviderResult<CorpoClinicoDTO>> CorpoClinicoDataProvider(GridDataProviderRequest<CorpoClinicoDTO> request)
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
            CorpoClinico = await EstabelecimentoApiService.GetEstabelecimentoCorpoClinicoAsync(EstabelecimentoService.SelectedEstabelecimento.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        if (CorpoClinico is null)
        {
            return new GridDataProviderResult<CorpoClinicoDTO>()
            {
                Data = [],
                TotalCount = 0
            };
        }
        return await Task.FromResult(request.ApplyTo(CorpoClinico));
    }

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
