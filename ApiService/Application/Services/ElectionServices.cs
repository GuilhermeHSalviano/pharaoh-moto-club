using pharaoh_moto_club.Models;
using Utilities;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Dtos;
using My.Exceptions;
using pharaoh_moto_club.Factories;


namespace Services {
    public class ElectionServices {

        private readonly AppDbContext _context;

        public ElectionServices(AppDbContext context) {
            _context = context;
        }

        public async Task<Election?> GetFinishedNotClosedElection() {
            return await _context.Elections.Where(x => x.IsElectionClosed == false && x.EndingOfElection < BrazilTime.Now()).FirstOrDefaultAsync();
        }

        public async Task<Election?> GetElectionById(int electionId) {
            return await _context.Elections.FindAsync(electionId);
        }

        public async Task SaveElectionOnDb(ElectionDto incomingElection) {
            var election = await _context.Elections.FirstOrDefaultAsync(b => b.PositionToBeElected == incomingElection.PositionToBeElected && b.IsElectionClosed == false);
            var author = await _context.Members.FirstOrDefaultAsync(b => b.MemberId == incomingElection.AuthorId);
            if(incomingElection.BeginningOfElection > incomingElection.EndingOfElection) throw new MemberNotAllowed("Início da eleição não pode ser posterior ao final da eleição");
            if(incomingElection.EndingOfElection <= BrazilTime.Now()) throw new MemberNotAllowed("O início da eleição deve ser posterior ao momento atual");
            if (author == null) throw new EntityNotFound("O autor informado não existe"); 
            if (election != null) throw new MemberNotAllowed("Já existe uma eleição aberta para este cargo"); 
            Election newElection = ElectionFactory.CreateElection(incomingElection);
            _context.Elections.Add(newElection);
            await _context.SaveChangesAsync();
        }
        
        /*public async Task CloseElections(
            CandidacyServices candidacyServices, 
            ElectionCountingServices electionCountingServices,
            VotesServices votesServices,
            AppDbContext context,
            CancellationToken cancellationToken
            ) {
            var election = await GetFinishedNotClosedElection();

            if (election != null) {
                var candidates = candidacyServices.GetCandidatesByElection(election);
                var counting = electionCountingServices.GetElectionCountingResult(candidates, election);
                var rejectionVotes = votesServices.CountRejectionVotes(election);
                var tie = false;
                VotesPerCandidate possibleWinner = new VotesPerCandidate(0, 0);

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
        }*/
    }
    
}