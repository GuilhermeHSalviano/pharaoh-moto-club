using pharaoh_moto_club.Models;
using Utilities;
using Microsoft.EntityFrameworkCore;


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
    }
}