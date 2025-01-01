// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using weges_v2.ApiModel;
using weges_v2.UsersMigrations;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DBInitializer>();

builder.AddServiceDefaults();

builder.Services
    .AddDbContextPool<UtilizadoresDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        b =>
        {
            b.MigrationsAssembly("weges-v2.UsersMigrations");
            b.MigrationsHistoryTable("__EFMigrationsHistory_Weges_Users");
        }));

builder.EnrichNpgsqlDbContext<UtilizadoresDbContext>(settings =>
    // Disable Aspire default retries as we're using a custom execution strategy
    settings.DisableRetry = true);

var app = builder.Build();

app.Run();
