using Microsoft.AspNetCore.Authentication.Cookies;
//TESTE
using Services;

using Web.Components;
using Web.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Path to your login page
        options.LogoutPath = "/logout"; // Path to handle logouts
        options.Cookie.HttpOnly = false; // Ensure the cookie is not accessible via JavaScript
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Use HTTPS for production
        options.Cookie.SameSite = SameSiteMode.Strict; // Prevent cross-site requests
        options.ExpireTimeSpan = TimeSpan.FromHours(1); // Set cookie expiration
    });

builder.Services.AddBlazorBootstrap();

builder.Services.AddHttpClient<EntidadeApiService>(client =>
    {
        client.BaseAddress = new("https+http://apiservice");
    });

builder.Services.AddHttpClient<EstabelecimentoApiService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});

builder.Services.AddHttpClient<DirecaoClinicaApiService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});

builder.Services.AddHttpClient<ServicosApiService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});

builder.Services.AddHttpClient<IdentityService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});
builder.Services.AddHttpClient<TipologiaApiService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});
builder.Services.AddHttpClient<IdentityService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});

builder.Services.AddSingleton<EstabelecimentoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
