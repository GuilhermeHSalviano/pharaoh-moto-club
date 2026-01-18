using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;
using Services;


namespace ElectionBackgroundService;

public class Worker : BackgroundService {

    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(IServiceScopeFactory serviceScopeFactory) {
        _scopeFactory = serviceScopeFactory;
    }

    public class VotesPerCandidate {

        public int candidateId { get; set; }
        public int votesReceived { get; set; }
        public VotesPerCandidate(int id, int votes) {
            candidateId = id;
            votesReceived = votes;
        }
    }

    public async Task GetAndCloseElectionAsync(
            AppDbContext context,
            CancellationToken cancellationToken,
            ElectionServices electionServices
        ) {
            var election = await electionServices.GetFinishedNotClosedElection();

            if (election != null) {
                var candidates = context.Candidacy.Where(x => x.ElectionId == election.ElectionId).Select(b => b.CandidateId).ToList();
                var counting = new List<VotesPerCandidate>();
                var nullVotes = context.Votes.Count(c => c.ElectionId == election.ElectionId && c.CandidateId == null);
                var rejectionVotes = context.Votes.Count(c => c.ElectionId == election.ElectionId && c.IsCandidatesRejected == true);
                var tie = false;
                VotesPerCandidate possibleWinner = new VotesPerCandidate(0, 0);

                for (int i = 0; i < candidates.Count; i++) {
                    var votes = context.Votes
                        .Count(c => c.CandidateId == candidates[i] && c.ElectionId == election.ElectionId);
                    var candidateVotes = new VotesPerCandidate(candidates[i], votes);
                    counting.Add(candidateVotes);
                }

                if (counting.Count == 0) {
                    election.IsElectionClosed = true;
                    await context.SaveChangesAsync();
                }
                else {
                    if (candidates.Count == 1 && counting[0].votesReceived > rejectionVotes) {
                        election.WinnerId = counting[0].candidateId;
                        election.IsElectionClosed = true;
                        await context.SaveChangesAsync();
                    }
                    else {
                        for (int i = 0; i < counting.Count; i++) {
                            if (counting[i].votesReceived > possibleWinner.votesReceived) {
                                possibleWinner = counting[i];
                                tie = false;
                            }
                            else if (counting[i].votesReceived == possibleWinner.votesReceived) {
                                tie = true;
                            }
                        }

                        if (tie == true || possibleWinner.votesReceived <= rejectionVotes) {
                            election.WinnerId = 0;
                        }
                        else {
                            election.WinnerId = possibleWinner.candidateId;
                        }

                        election.IsElectionClosed = true;
                        await context.SaveChangesAsync();
                    }

                    await context.SaveChangesAsync(cancellationToken);
            }
        }
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {

            try {
                using var scope = _scopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var electionServices = scope.ServiceProvider.GetRequiredService<ElectionServices>();


                await GetAndCloseElectionAsync(context, stoppingToken, electionServices);
                Console.WriteLine("testando");
                await Task.Delay(1000, stoppingToken);
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
