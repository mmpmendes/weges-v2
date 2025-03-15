using ApiModel;
using ApiModel.Models;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;
using MudBlazor.Translations;

using Services;

using WebApp.Components;
using WebApp.Components.Account;
using WebApp.InMemory;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("weges") ?? throw new InvalidOperationException("Connection string 'weges' not found.");
builder.Services.AddDbContext<UtilizadoresDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<SignInManager<WegesUser>>();
builder.Services.AddScoped<UserManager<WegesUser>>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddIdentityCookies();

builder.Services.AddIdentityCore<WegesUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<UtilizadoresDbContext>()
    .AddSignInManager<SignInManager<WegesUser>>()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<WegesUser>, IdentityNoOpEmailSender>();
builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();
builder.Services.AddMudTranslations();

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

var app = builder.Build();


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

app.UseAntiforgery();

app.UseAuthentication();


app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapDefaultEndpoints();
// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
