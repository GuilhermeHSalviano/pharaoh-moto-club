using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class VotesController : ControllerBase {
        private readonly AppDbContext _context;

        public VotesController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ToVote(CreateVoteDto MyVote) {
            var voter = await _context.Members.FirstOrDefaultAsync(x => x.MemberId == MyVote.VoterId);
            if(voter == null) return NotFound("Este membro votante não existe");
            if(voter.CoatOfArms == false) return Conflict("Este membro não pode votar, pois não possui brasão");
            var didMemberAlreadyVote = await _context.Votes.FirstOrDefaultAsync(x => x.VoterId == MyVote.VoterId && x.ElectionId == MyVote.ElectionId) != null;
            if (didMemberAlreadyVote) return Conflict("Este membro já votou nesta eleição");

            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == MyVote.CandidateId && x.ElectionId == MyVote.ElectionId) != null;
            if (MyVote.IsCandidatesRejected == false && !doesCandidateExist) {
                return BadRequest("Este candidato não existe");
            }

            if (MyVote.IsCandidatesRejected == true && MyVote.CandidateId != null) return BadRequest("O membro não pode votar em um candidato e rejeitá-lo ao mesmo tempo");

            _context.Votes.Add(VoteFactory.CreateVote(MyVote));

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}
