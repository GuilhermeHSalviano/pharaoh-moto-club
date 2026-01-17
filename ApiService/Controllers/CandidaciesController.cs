using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CandidaciesController : ControllerBase {
        private readonly AppDbContext _context;

        public CandidaciesController(AppDbContext context) {
            _context = context;
        }

        [HttpPost("{electionId}/{candidateId}")]
        public async Task<IActionResult> CreateCandidacy(int electionId, int candidateId ) {
            var election = await _context.Elections.FirstOrDefaultAsync(c => c.ElectionId == electionId);
            if(election == null) return NotFound("Esta eleição não existe");
            if(election.IsElectionClosed == true || election.EndingOfElection < DateTime.UtcNow) return Conflict("Esta eleição já se iniciou ou já se encontra fechada");
            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == candidateId && x.ElectionId == electionId) != null;
            if (doesCandidateExist) return Conflict("Este candidato já se candidatou para esta eleição");
            var candidacy = new Candidacy(electionId, candidateId);
            _context.Candidacy.Add(candidacy);
            _context.SaveChanges();
            return Ok(candidacy);
        }
    }
}
