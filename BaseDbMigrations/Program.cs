// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ApiModel;

using BaseDbMigrations;

using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<WegesDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        b =>
        {
            b.MigrationsAssembly("BaseDbMigrations");
            b.MigrationsHistoryTable("__EFMigrationsHistory", "weges");
        }));

builder.Services
    .AddDbContext<UtilizadoresDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        b =>
        {
            b.MigrationsAssembly("IdentityMigrations");
            b.MigrationsHistoryTable("__EFMigrationsHistory", "weges_users");
        }));

builder.Services.AddHostedService<DbInitializer<WegesDbContext>>();
builder.Services.AddHostedService<DbInitializer<UtilizadoresDbContext>>();
builder.Services.AddHostedService<SeedDataWeges>();

builder.AddServiceDefaults();



var app = builder.Build();

app.Run();
