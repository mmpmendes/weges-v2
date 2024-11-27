var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();


var db = postgres.AddDatabase("weges");

var migrationService = builder.AddProject<Projects.weges_v2_DbMigrations>("migration")
    .WithReference(db)
    .WaitFor(db);

var apiService = builder.AddProject<Projects.weges_v2_ApiService>("apiservice")
                    .WithReference(db)
                    .WaitForCompletion(migrationService);

builder.AddProject<Projects.weges_v2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
