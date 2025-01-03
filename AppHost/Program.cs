var builder = DistributedApplication.CreateBuilder(args);

//var cache = builder.AddRedis("cache")//.WithLifetime(ContainerLifetime.Persistent)
//    .WithContainerName("weges-cache");

var postgres = builder.AddPostgres("pgserver")
                      .WithContainerName("pgserver").WithPgAdmin();//.WithLifetime(ContainerLifetime.Persistent);

var db = postgres.AddDatabase("weges");
var apiService = builder.AddProject<Projects.ApiService>("apiservice")
                    .WithReference(db)
                    .WaitFor(db);

var migrationService = builder.AddProject<Projects.DbMigrations>("weges-migration")
    .WithReference(db)
    .WaitFor(db)
    .WaitFor(apiService);

//var usersMigrationService = builder.AddProject<Projects._UsersMigrations>("users-migration")
//    .WithReference(db)
//    .WaitFor(db)
//    .WaitFor(migrationService);



builder.AddProject<Projects.Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
