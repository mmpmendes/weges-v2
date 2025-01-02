// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using ApiModel;

using DbMigrations;

using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DBInitializer<WegesDbContext>>();
builder.Services.AddHostedService<DBInitializer<UtilizadoresDbContext>>();

builder.AddServiceDefaults();

builder.Services.AddDbContextPool<WegesDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        b =>
        {
            b.MigrationsAssembly("DbMigrations");
            b.MigrationsHistoryTable("__EFMigrationsHistory_Weges");
        }));

builder.Services
    .AddDbContextPool<UtilizadoresDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        b =>
        {
            b.MigrationsAssembly("UsersMigrations");
            b.MigrationsHistoryTable("__EFMigrationsHistory_Weges_Users");
        }));

var app = builder.Build();

app.Run();
