// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore;

using weges_v2.ApiModel;
using weges_v2.DbMigrations;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<DBInitializer>();

builder.AddServiceDefaults();

builder.Services.AddDbContextPool<WegesDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("weges"),
        b => b.MigrationsAssembly("weges-v2.DbMigrations")));
builder.EnrichNpgsqlDbContext<WegesDbContext>();

var app = builder.Build();

app.Run();
