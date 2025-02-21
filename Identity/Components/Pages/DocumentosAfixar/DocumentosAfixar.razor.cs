using Identity.InMemory;

using Microsoft.AspNetCore.Components;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.DocumentosAfixar;

public partial class DocumentosAfixar
{
    [Inject] EstabelecimentoApiService EstabelecimentoApiService { get; set; } = default!;
    [Inject] EstabelecimentoService EstabelecimentoService { get; set; } = default!;

    private IList<FicheirosLicenciamentoDTO>? ListasVerificacao = default!;
    private MudDataGrid<FicheirosLicenciamentoDTO> ListaVerificacaoGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? FicheirosAnexar = default!;
    private MudDataGrid<FicheirosLicenciamentoDTO> FicheirosAnexarGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? CartasDireitosDeveres = default!;
    private MudDataGrid<FicheirosLicenciamentoDTO> CartaDireitosDeveresGrid = default!;

    private IList<FicheirosLicenciamentoDTO>? LicenciamentosRegistosLegais = default!;
    private MudDataGrid<FicheirosLicenciamentoDTO> LicenciamentoRegistoLegalGrid = default!;

    private async Task<GridData<FicheirosLicenciamentoDTO>> ListaVerificacaoDataProvider(GridState<FicheirosLicenciamentoDTO> state)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        //if (request.Sorting is not null && request.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = request.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        //}

        try
        {
            //ListasVerificacao = await EstabelecimentoApiService.GetEstabelecimentoListasVerificacao(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (ListasVerificacao is null)
        {
            return new GridData<FicheirosLicenciamentoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<FicheirosLicenciamentoDTO>()
        {
            Items = ListasVerificacao,
            TotalItems = ListasVerificacao.Count
        };
    }

    private async Task<GridData<FicheirosLicenciamentoDTO>> FicheirosAnexarDataProvider(GridState<FicheirosLicenciamentoDTO> state)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        //if (request.Sorting is not null && request.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = request.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        //}

        try
        {
            //FicheirosAnexar = await EstabelecimentoApiService.GetEstabelecimentosFicheirosAnexarAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (FicheirosAnexar is null)
        {
            return new GridData<FicheirosLicenciamentoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<FicheirosLicenciamentoDTO>()
        {
            Items = FicheirosAnexar,
            TotalItems = FicheirosAnexar.Count
        };
    }

    private async Task<GridData<FicheirosLicenciamentoDTO>> CartaDireitosDeveresDataProvider(GridState<FicheirosLicenciamentoDTO> state)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        //if (request.Sorting is not null && request.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = request.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = request.Sorting.FirstOrDefault()!.SortDirection;
        //}

        try
        {
            //CartasDireitosDeveres = await EstabelecimentoApiService.GetEstabelecimentosCartaDireitosDeveresAsync(EstabelecimentoService.SelectedEstabelecimento.Id, request.Filters, request.PageNumber, request.PageSize, sortString, sortDirection, request.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (CartasDireitosDeveres is null)
        {
            return new GridData<FicheirosLicenciamentoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<FicheirosLicenciamentoDTO>()
        {
            Items = CartasDireitosDeveres,
            TotalItems = CartasDireitosDeveres.Count
        };
    }

    private async Task<GridData<FicheirosLicenciamentoDTO>> LicenciamentoRegistoLegalDataProvider(GridState<FicheirosLicenciamentoDTO> state)
    {
        string sortString = "";
        SortDirection sortDirection = SortDirection.None;

        //if (state.Sorting is not null && state.Sorting.Any())
        //{
        //    // Note: Multi column sorting is not supported at this moment
        //    sortString = state.Sorting.FirstOrDefault()!.SortString;
        //    sortDirection = state.Sorting.FirstOrDefault()!.SortDirection;
        //}
        try
        {
            //LicenciamentosRegistosLegais = await EstabelecimentoApiService.GetEstabelecimentosLicenciamentosLegaisAsync(EstabelecimentoService.SelectedEstabelecimento.Id, state.Filters, state.PageNumber, state.PageSize, sortString, sortDirection, state.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        if (LicenciamentosRegistosLegais is null)
        {
            return new GridData<FicheirosLicenciamentoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }

        return new GridData<FicheirosLicenciamentoDTO>()
        {
            Items = LicenciamentosRegistosLegais,
            TotalItems = LicenciamentosRegistosLegais.Count
        };
    }
}
