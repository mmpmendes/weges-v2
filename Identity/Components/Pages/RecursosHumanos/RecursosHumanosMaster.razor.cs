using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.RecursosHumanos;

public partial class RecursosHumanosMaster
{
    private IList<ServicoDTO>? Servicos = default!;
    private MudDataGrid<ServicoDTO> ServicosGrid = default!;

    private IList<CorpoClinicoDTO>? CorpoClinico = default!;
    private MudDataGrid<CorpoClinicoDTO> CorpoClinicoGrid = default!;

    [Inject]
    public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    [Inject]
    public required EstabelecimentoService EstabelecimentoService { get; set; }

    // Note: This method is used to provide the data for the grid
    private async Task<GridData<ServicoDTO>> ServicosDataProvider(GridState<ServicoDTO> state)
    {
        //string sortString = "";
        //SortDirection sortDirection = SortDirection.None;

        //if (state.Sorting is not null && state.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = state.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = state.Sorting.FirstOrDefault()!.SortDirection;
        //}

        Servicos = await EstabelecimentoApiService.GetEstabelecimentoServicosAsync(EstabelecimentoService.SelectedEstabelecimento.Id);
        if (Servicos is null)
        {
            return new GridData<ServicoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<ServicoDTO>()
        {
            Items = Servicos,
            TotalItems = Servicos.Count
        };
    }

    // Note: This method is used to provide the data for the grid
    private async Task<GridData<CorpoClinicoDTO>> CorpoClinicoDataProvider(GridState<CorpoClinicoDTO> state)
    {
        //string sortString = "";
        //SortDirection sortDirection = SortDirection.None;

        //if (state.Sorting is not null && state.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = state.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = state.Sorting.FirstOrDefault()!.SortDirection;
        //}
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
            return new GridData<CorpoClinicoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }
        return new GridData<CorpoClinicoDTO>()
        {
            Items = CorpoClinico,
            TotalItems = CorpoClinico.Count
        };
    }

    //private async Task<IEnumerable<FilterOperatorInfo>> GridFiltersTranslationProvider()
    //{
    //    var filtersTranslation = new List<FilterOperatorInfo>();

    //    // number/date/boolean
    //    filtersTranslation.Add(new("=", "é igual", FilterOperator.Equals));
    //    filtersTranslation.Add(new("!=", "não é igual", FilterOperator.NotEquals));
    //    // number/date
    //    filtersTranslation.Add(new("<", "é menor", FilterOperator.LessThan));
    //    filtersTranslation.Add(new("<=", "é menor ou igual", FilterOperator.LessThanOrEquals));
    //    filtersTranslation.Add(new(">", "é maior", FilterOperator.GreaterThan));
    //    filtersTranslation.Add(new(">=", "é maior ou igual", FilterOperator.GreaterThanOrEquals));
    //    // string
    //    filtersTranslation.Add(new("*a*", "contém", FilterOperator.Contains));
    //    filtersTranslation.Add(new("!*a*", "não contém", FilterOperator.DoesNotContain));
    //    filtersTranslation.Add(new("a**", "começa com", FilterOperator.StartsWith));
    //    filtersTranslation.Add(new("**a", "termina com", FilterOperator.EndsWith));
    //    filtersTranslation.Add(new("=", "é igual", FilterOperator.Equals));
    //    // common
    //    filtersTranslation.Add(new("x", "limpar", FilterOperator.Clear));

    //    return await Task.FromResult(filtersTranslation);
    //}
}
