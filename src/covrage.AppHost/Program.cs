var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Example_API>("example-api");

builder.Build().Run();
