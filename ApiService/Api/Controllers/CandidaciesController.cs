using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My.Exceptions;
using pharaoh_moto_club.Models;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CandidaciesController : ControllerBase {
        private readonly CandidacyServices _candidacyServices;

        public CandidaciesController(CandidacyServices candidacyServices) {
            _candidacyServices = candidacyServices;
        }

        [HttpPost("{electionId}/{candidateId}")]
        public async Task<IActionResult> CreateCandidacy(int electionId, int candidateId ) {
            try {
                await _candidacyServices.SaveCandidacyOnDb(electionId, candidateId);
                return NoContent();
            } catch(EntityNotFound error) {
                return NotFound(error.Message);
            } catch(MemberNotAllowed error) {
                return Conflict(error.Message);
            }
        }
    }
}
