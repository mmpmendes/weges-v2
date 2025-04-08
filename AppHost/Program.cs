var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache")
//                   .WithRedisCommander().WithLifetime(ContainerLifetime.Persistent);

var postgres = builder.AddPostgres("pgserver")
                      .WithContainerName("pgserver")
                      .WithLifetime(ContainerLifetime.Persistent)
                      .WithPgAdmin();

var db = postgres.AddDatabase("weges");

var apiService = builder.AddProject<Projects.WebApi>("apiservice")
                    .WithReference(db)
                    .WaitFor(postgres)
                    .WaitFor(db);
//.WithReference(cache);

var migrationService = builder.AddProject<Projects.BaseDbMigrations>("weges-migration")
    .WithReference(db)
    .WaitFor(postgres)
    .WaitFor(db)
    .WaitFor(apiService);

builder.AddProject<Projects.WebApp>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(db)
    .WaitFor(postgres)
    .WaitFor(db)
    .WaitFor(apiService)
    .WaitFor(migrationService);
//.WithReference(cache);

builder.Build().Run();
