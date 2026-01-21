using pharaoh_moto_club.Models;

namespace Services {
    public class CandidacyServices {
        private readonly AppDbContext _context;

        public CandidacyServices(AppDbContext context) {
            _context = context;
        }

        public List<int> GetCandidatesByElection(Election election) {
            return  _context.Candidacy.Where(x => x.ElectionId == election.ElectionId).Select(b => b.CandidateId).ToList();
        }
    }
}