using ApiModel;
using ApiModel.Models;

using Identity.Components;
using Identity.Components.Account;
using Identity.InMemory;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
//builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorization();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddGoogle(authenticationScheme: "Google", displayName: "Google", options =>
    {
        options.ClientId = builder.Configuration["Google:ClientId"];
        options.ClientSecret = builder.Configuration["Google:ClientSecret"];
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("weges") ?? throw new InvalidOperationException("Connection string 'weges' not found.");
builder.Services.AddDbContext<UtilizadoresDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<WegesUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UtilizadoresDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<WegesUser>, IdentityNoOpEmailSender>();

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

builder.Services.AddHttpClient<TipologiaApiService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});
builder.Services.AddHttpClient<FicheiroApiService>(client =>
{
    client.BaseAddress = new("https+http://apiservice");
});
builder.Services.AddSingleton<EstabelecimentoService>();

builder.Services.AddAntiforgery();
var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseOutputCache();


app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
