using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using weges_v2.ApiModel;
using weges_v2.ApiModel.Models;
using weges_v2.ApiService.Data;
using weges_v2.SharedKernel.Models;

var builder = WebApplication.CreateBuilder(args);

var AllowSpecificOrigins = "AllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://mmendes-weges.ddns.net", "http://localhost:4200");
            policy.AllowAnyMethod();
            policy.AllowCredentials();
            policy.AllowAnyHeader();
        });
});

builder.Services.AddIdentityCore<WegesUser>()
                .AddEntityFrameworkStores<WegesDbContext>()
                .AddApiEndpoints()
                .AddErrorDescriber<PortugueseIdentityErrorDescriber>(); // Add this line;

builder.Services.AddDbContextPool<WegesDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("weges"))
    );

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddScoped<ISimpleRepository<Entidade>, SimpleRepository<Entidade>>();
builder.Services.AddScoped<ISimpleRepository<Estabelecimento>, SimpleRepository<Estabelecimento>>();


builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
                .AddCookie(IdentityConstants.ApplicationScheme)
                .AddBearerToken(IdentityConstants.BearerScheme);




// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "weges.api", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapDefaultEndpoints();
app.MapControllers();
app.MapIdentityApi<WegesUser>();

app.Run();
