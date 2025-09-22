using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ElectionsController : ControllerBase {
        private readonly AppDbContext _context;

        public ElectionsController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateElection(Election model) {
            _context.Elections.Add(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPost("{ElectionId}")]
        public async Task<IActionResult> CloseElection(int electionId, List<int> Candidates) {
            var election = await _context.Elections.FindAsync(electionId);
            var numberOfVotes = new List<Votes>();
            for(int i = 0; i < Candidates.Count; i++) {
                var votesOfCandidate = _context.Votes
                    .Count(c => c.CandidateId == Candidates[i] && c.ElectionId == electionId);
                //Now you need to add to numberOfVotes an object containing the Id of the candidate and the number of votes he's received

            }
        }     

        

    }
}
