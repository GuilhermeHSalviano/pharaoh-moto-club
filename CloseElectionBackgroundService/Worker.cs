namespace CloseElectionBackgroundService;

public class Worker : BackgroundService
{
    private readonly MyHttpClient _myHttpClient;
    public Worker(MyHttpClient myHttpClient)
    {
        _myHttpClient = myHttpClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _myHttpClient.GetFinishedElectionAsync();
            await Task.Delay(1000, stoppingToken);
        }
    }
}
