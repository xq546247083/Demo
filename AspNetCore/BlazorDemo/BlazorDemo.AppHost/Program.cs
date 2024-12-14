var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BlazorDemo>("blazordemo");

builder.Build().Run();
