using pharaoh_moto_club.Models;

namespace Services {
    public class VotesServices {
        private readonly AppDbContext _context;

        public VotesServices(AppDbContext context) {
            _context = context;
        }

        public int CountNullVotes(Election election) {
            return _context.Votes.Count(c => c.ElectionId == election.ElectionId && c.CandidateId == null);
        }

        public int CountRejectionVotes(Election election) {
            return _context.Votes.Count(c => c.ElectionId == election.ElectionId && c.IsCandidatesRejected == true);
        }
    }

}