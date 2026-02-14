using pharaoh_moto_club.Models;

namespace Services;

public class CloseElectionService {
    static public async Task CloseElections(
            AppDbContext context,
            CancellationToken cancellationToken,
            ElectionServices electionServices,
            VotesServices votesServices,
            CandidacyServices candidacyServices, 
            ElectionCountingServices electionCountingServices
            ) {
            var election = await electionServices.GetFinishedNotClosedElection();

            if (election != null) {
                var candidates = candidacyServices.GetCandidatesByElection(election);
                var counting = electionCountingServices.GetElectionCountingResult(candidates, election);
                var rejectionVotes = votesServices.CountRejectionVotes(election);
                var tie = false;
                VotesPerCandidate possibleWinner = new VotesPerCandidate(0, 0);

                if (counting.Count == 0 || ElectionCountingServices.DidAnybodyVote(counting)) {
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
}