using pharaoh_moto_club.Models;
using Services;


namespace ElectionBackgroundService;

public class Worker : BackgroundService {

    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(IServiceScopeFactory serviceScopeFactory) {
        _scopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {

            try {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var electionServices = scope.ServiceProvider.GetRequiredService<ElectionServices>();
                var votesServices = scope.ServiceProvider.GetRequiredService<VotesServices>();
                var candidacyServices = scope.ServiceProvider.GetRequiredService<CandidacyServices>();
                var electionCountingServices = scope.ServiceProvider.GetRequiredService<ElectionCountingServices>();


                await CloseElectionService.CloseElections(context, stoppingToken, electionServices, votesServices, candidacyServices, electionCountingServices);
                Console.WriteLine("testando");
                await Task.Delay(10000, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) {
                // graceful shutdown
            }

            catch (Exception error) {
                Console.WriteLine($"Erro no background service: {error}");
                await Task.Delay(5000, stoppingToken);
            }


        }
    }
}
