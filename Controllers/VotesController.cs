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

        [HttpPost]
        public async Task<IActionResult> ToVote(Votes MyVote) {
            var didMemberAlreadyVote = await _context.Votes.FirstOrDefaultAsync(x => x.VoterId == MyVote.VoterId && x.ElectionId == MyVote.ElectionId) != null;
            if (didMemberAlreadyVote) return BadRequest("This member has already voted in this election");

            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == MyVote.CandidateId && x.ElectionId == MyVote.ElectionId) != null;
            if (MyVote.IsCandidatesRejected == false && !doesCandidateExist) {
                return BadRequest("The candidate does not exist");
            }

            if (MyVote.IsCandidatesRejected == true && MyVote.CandidateId != null) return BadRequest("The member cannot vote in a candidate and reject him at the same time");

            _context.Votes.Add(MyVote);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
