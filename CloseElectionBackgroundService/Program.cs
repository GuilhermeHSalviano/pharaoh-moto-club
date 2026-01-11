using CloseElectionBackgroundService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddHttpClient();
builder.Services.AddTransient<MyHttpClient>();
var host = builder.Build();
host.Run();
