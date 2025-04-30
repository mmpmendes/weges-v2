using ApiModel;
using ApiModel.Models;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using MudBlazor.Services;
using MudBlazor.Translations;

using Services;

using WebApp;
using WebApp.Components;
using WebApp.Components.Account;
using WebApp.InMemory;

// FDS ULTIMA TENTATIVA
var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("weges") ?? throw new InvalidOperationException("Connection string 'weges' not found.");
builder.Services.AddDbContext<UtilizadoresDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IEmailService, EmailService>();
builder.Services.Configure<EmailConfiguracoes>(builder.Configuration.GetSection("EmailConfiguracoes"));
builder.Services.AddSingleton<IEmailSender<WegesUser>, CustomEmailSender>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<UploadService>();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();
builder.Services.AddScoped<SignInManager<WegesUser>>();
builder.Services.AddScoped<UserManager<WegesUser>>();

builder.Services.AddIdentityCore<WegesUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddUserManager<UserManager<WegesUser>>()
    .AddEntityFrameworkStores<UtilizadoresDbContext>()
    .AddSignInManager<SignInManager<WegesUser>>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ApplicationScheme;
})
//.AddGoogle(authenticationScheme: "Google", displayName: "Google", options =>
//{
//    options.ClientId = builder.Configuration["Google:ClientId"];
//    options.ClientSecret = builder.Configuration["Google:ClientSecret"];
//})
.AddIdentityCookies();

builder.Services.AddSingleton<IEmailSender<WegesUser>, CustomEmailSender>();
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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await IdentitySeeder.SeedUsersAsync(services, builder.Configuration);
}

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
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapDefaultEndpoints();
// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
