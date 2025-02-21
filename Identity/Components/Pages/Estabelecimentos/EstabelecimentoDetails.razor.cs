using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.WebUtilities;

using MudBlazor;

using Services;

using SharedKernel.DTO;

namespace Identity.Components.Pages.Estabelecimentos;

public partial class EstabelecimentoDetails
{
    [Parameter]
    public long Id { get; set; }

    [Inject]
    public required EstabelecimentoApiService EstabelecimentoApiService { get; set; }
    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    private IList<ServicoDTO>? Servicos = default!;
    private IList<DirecaoClinicaDTO>? DirecoesClinicas = default!;
    private MudDataGrid<ServicoDTO>? ServicosGrid;
    private MudDataGrid<DirecaoClinicaDTO>? DirecoesClinicasGrid;
    private MudTabs Tabs = default!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var uri = NavigationManager.ToAbsoluteUri(NavigationManager.Uri);
        var queryParameters = QueryHelpers.ParseQuery(uri.AbsoluteUri);
        string value = queryParameters.FirstOrDefault().Value;
        if (!String.IsNullOrEmpty(value))
        {
            if (value == "dircli")
            {
                //await Tabs.ShowTabByIndexAsync(1);
                Tabs.ActivatePanel(1);
            }
            else if (value == "servico")
            {
                //await Tabs.ShowTabByIndexAsync(2);
                Tabs.ActivatePanel(2);
            }
        }
    }

    private async Task<GridData<DirecaoClinicaDTO>> DirecoesClinicasDataProvider(GridState<DirecaoClinicaDTO> state)
    {
        if (Id > -1)
        {
            DirecoesClinicas = await EstabelecimentoApiService.GetEstabelecimentoDirecoesClinicasAsync(Id);
        }

        if (DirecoesClinicas is null)
        {
            return new GridData<DirecaoClinicaDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }
        return new GridData<DirecaoClinicaDTO>
        {
            Items = DirecoesClinicas,
            TotalItems = DirecoesClinicas.Count
        };
    }

    private async Task<GridData<ServicoDTO>> ServicosDataProvider(GridState<ServicoDTO> state)
    {
        if (Id > -1)
        {
            Servicos = await EstabelecimentoApiService.GetEstabelecimentoServicosAsync(Id);
        }

        if (Servicos is null)
        {
            return new GridData<ServicoDTO>()
            {
                Items = [],
                TotalItems = 0
            };
        }
        return new GridData<ServicoDTO>
        {
            Items = Servicos,
            TotalItems = Servicos.Count
        };
    }
    private void AddDirecaoClinica(MouseEventArgs e)
    {
        NavigationManager.NavigateTo($"/Estabelecimentos/{Id}/DirecaoClinica");
    }
    private void AddServico(MouseEventArgs e)
    {
        NavigationManager.NavigateTo($"/Estabelecimentos/{Id}/Servico");
    }
    //private void OnDirecoesClinicasRowClick(GridRowEventArgs<DirecaoClinicaDTO> direcaoClinica)
    //{
    //    NavigationManager.NavigateTo($"/Estabelecimentos/{Id}/DirecaoClinica/{direcaoClinica.Item.Id}");
    //}

    private void EditarDirecaoClinica(long direcaoClinicaId)
    {
        NavigationManager.NavigateTo($"/Estabelecimentos/{Id}/DirecaoClinica/{direcaoClinicaId}");
    }

    //private void OnServicosRowClick(GridRowEventArgs<ServicoDTO> servico)
    //{
    //    NavigationManager.NavigateTo($"/Estabelecimentos/{Id}/Servico/{servico.Item.Id}");
    //}

    private void EditarServico(long servicoId)
    {
        NavigationManager.NavigateTo($"/Estabelecimentos/{Id}/Servico/{servicoId}");
    }
}
