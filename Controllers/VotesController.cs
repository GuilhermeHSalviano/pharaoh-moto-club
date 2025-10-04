using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class VotesController : ControllerBase {
        private readonly AppDbContext _context;

        public VotesController(AppDbContext context) {
            _context = context;
        }

        [HttpPost("{voterId}/{electionId}/{candidateId}")]
        public async Task<IActionResult> ToVote(int voterId, int electionId, int candidateId) {
            var vote = new Votes(voterId, electionId, candidateId);
            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == candidateId && x.ElectionId == electionId) != null;
            var didHeVote = await _context.Votes.FirstOrDefaultAsync(x => x.VoterId == voterId && x.ElectionId == electionId) != null;
            if (!doesCandidateExist) return BadRequest("The candidate does not exist");
            if (didHeVote) return BadRequest("This member has already voted in this election");
            _context.Votes.Add(vote);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
