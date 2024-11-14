var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();
var db = postgres.AddDatabase("weges");

var apiService = builder.AddProject<Projects.weges_v2_ApiService>("apiservice")
                        .WithReference(db);

// var migrationService = builder.AddProject<Projects.DatabaseMigrations_MigrationService>("migration")
//     .WithReference(db1)
//     .WaitFor(db1);

builder.AddProject<Projects.weges_v2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
