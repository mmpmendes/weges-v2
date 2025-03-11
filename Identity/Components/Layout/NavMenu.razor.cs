using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace WebApp.Components.Layout;

public partial class NavMenu
{
    [Inject] NavigationManager NavigationManager { get; set; } = default!;
    private string? currentUrl;

    protected override void OnInitialized()
    {
        currentUrl = NavigationManager.ToBaseRelativePath(NavigationManager.Uri);
        NavigationManager.LocationChanged += OnLocationChanged;
    }

    private void OnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        currentUrl = NavigationManager.ToBaseRelativePath(e.Location);
        StateHasChanged();
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= OnLocationChanged;
    }
}
