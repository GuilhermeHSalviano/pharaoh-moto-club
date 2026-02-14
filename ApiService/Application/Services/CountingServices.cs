using pharaoh_moto_club.Models;

namespace Services {
    public class ElectionCountingServices {
        private readonly AppDbContext _context;

        public ElectionCountingServices(AppDbContext context) {
            _context = context;
        }

        public List<VotesPerCandidate> GetElectionCountingResult(List<int> candidates, Election election) {
            var counting = new List<VotesPerCandidate>();
            if(candidates == null) return counting;
            for (int i = 0; i < candidates.Count; i++) {
                var votes = _context.Votes
                    .Count(c => c.CandidateId == candidates[i] && c.ElectionId == election.ElectionId);
                var candidateVotes = new VotesPerCandidate(candidates[i], votes);
                counting.Add(candidateVotes);
            }
            return counting;
        }

        static public bool CheckIfNobodyVoted(List<VotesPerCandidate> counting) {
            var votes = 0;
            foreach(VotesPerCandidate candidate in counting) {
                votes = candidate.votesReceived++;
            }
            return votes == 0;
        }
    }
}