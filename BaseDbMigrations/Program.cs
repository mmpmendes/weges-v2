// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ApiModel;

using BaseDbMigrations;

using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<WegesDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        postgresOptions =>
        {
            postgresOptions.MigrationsAssembly("BaseDbMigrations");
            postgresOptions.MigrationsHistoryTable("__EFMigrationsHistory", "weges");
        }));

builder.Services
    .AddDbContext<UtilizadoresDbContext>(options =>
    {
        options.UseNpgsql(
            builder.Configuration.GetConnectionString("weges"),
            postgresOptions =>
            {
                postgresOptions.MigrationsAssembly("IdentityMigrations");
                postgresOptions.MigrationsHistoryTable("__EFMigrationsHistory", "weges_users");
            });
    });
builder.EnrichNpgsqlDbContext<WegesDbContext>(settings =>
{
    settings.DisableRetry = true;
});
builder.EnrichNpgsqlDbContext<UtilizadoresDbContext>(settings =>
{
    settings.DisableRetry = true;
});

builder.Services.AddHostedService<DbInitializer>();
//builder.Services.AddHostedService<DbInitializer<UtilizadoresDbContext>>();
//builder.Services.AddHostedService<SeedDataWeges>();

builder.AddServiceDefaults();

var app = builder.Build();

app.Run();
