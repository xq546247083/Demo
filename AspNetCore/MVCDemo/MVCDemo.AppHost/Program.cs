var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MVCDemo>("mvcdemo");

builder.Build().Run();
