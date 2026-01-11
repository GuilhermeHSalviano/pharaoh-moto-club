using CloseElectionBackgroundService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddHttpCliente();

var host = builder.Build();
host.Run();
