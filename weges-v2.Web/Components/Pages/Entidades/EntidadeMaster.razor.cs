﻿using BlazorBootstrap;

using Microsoft.AspNetCore.Components;

using weges_v2.Services;
using weges_v2.SharedKernel.DTO;

namespace weges_v2.Web.Components.Pages.Entidades;

public partial class EntidadeMaster
{
    private IList<EntidadeDTO>? Entidades = default!;
    private Grid<EntidadeDTO> EntidadesGV = default!;

    [Inject]
    public required EntidadeApiService EntidadeCli { get; set; }

    [Inject]
    public required NavigationManager NavigationManager { get; set; }

    protected async override Task OnInitializedAsync()
    {
        Entidades = await EntidadeCli.GetEntidadesAsync();
    }

    private void NavigateToDetails(long entidadeId)
    {
        NavigationManager.NavigateTo($"/entidade/{entidadeId}");
    }

    private async Task<GridDataProviderResult<EntidadeDTO>> EntidadesDataProvider(GridDataProviderRequest<EntidadeDTO> request)
    {
        if (Entidades is null)
            Entidades = await EntidadeCli.GetEntidadesAsync();

        return await Task.FromResult(request.ApplyTo(Entidades));
    }

    private async void AddEntidade(Microsoft.AspNetCore.Components.Web.MouseEventArgs e)
    {
        NavigateToDetails(-1);
    }
}
