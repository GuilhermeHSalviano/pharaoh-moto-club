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
            if (didMemberAlreadyVote) return Conflict("Este membro já votou nesta eleição");

            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == MyVote.CandidateId && x.ElectionId == MyVote.ElectionId) != null;
            if (MyVote.IsCandidatesRejected == false && !doesCandidateExist) {
                return BadRequest("Este candidato não existe");
            }

            if (MyVote.IsCandidatesRejected == true && MyVote.CandidateId != null) return BadRequest("O membro não pode votar em um candidato e rejeitá-lo ao mesmo tempo");

            _context.Votes.Add(MyVote);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
