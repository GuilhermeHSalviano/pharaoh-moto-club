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
            var doesCandidateExist = await _context.Candidacy.FirstOrDefaultAsync(x => x.CandidateId == candidateId && x.ElectionId == electionId) != null;
            if (doesCandidateExist) return BadRequest("This candidate has already candidated to this election");
            var candidacy = new Candidacy(electionId, candidateId);
            _context.Candidacy.Add(candidacy);
            _context.SaveChanges();
            return Ok(candidacy);
        }
    }
}
