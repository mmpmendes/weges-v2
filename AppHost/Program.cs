var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache")
                   .WithRedisCommander().WithLifetime(ContainerLifetime.Persistent);

var postgres = builder.AddPostgres("pgserver")
                      .WithContainerName("pgserver").WithPgAdmin().WithLifetime(ContainerLifetime.Persistent);

var db = postgres.AddDatabase("weges");
var apiService = builder.AddProject<Projects.ApiService>("apiservice")
                    .WithReference(db)
                    .WaitFor(db)
                    .WithReference(cache);

var migrationService = builder.AddProject<Projects.BaseDbMigrations>("weges-migration")
    .WithReference(db)
    .WaitFor(db)
    .WaitFor(apiService);

//builder.AddProject<Projects.Web>("webfrontend")
//    .WithExternalHttpEndpoints()
//    .WithReference(apiService)
//    .WaitFor(apiService)
//    .WithReference(cache);

builder.AddProject<Projects.Identity>("identity")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(db)
    .WaitFor(db)
    .WaitFor(apiService)
    .WaitFor(migrationService)
    .WithReference(cache);

builder.Build().Run();
