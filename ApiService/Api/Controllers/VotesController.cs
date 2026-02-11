using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;
using pharaoh_moto_club.Dtos;
using pharaoh_moto_club.Factories;
using My.Exceptions;
using Services;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class VotesController : ControllerBase {
        private readonly VotesServices _votesServices;

        public VotesController(VotesServices votesServices) {
            _votesServices = votesServices;
        }

        [HttpPost]
        public async Task<IActionResult> ToVote(CreateVoteDto MyVote) {
            try {
                await _votesServices.SaveVoteOnDb(MyVote);
                return NoContent();
            }catch(EntityNotFound error) {
                return NotFound(error.Message);
            }catch(MemberNotAllowed error) {
                return Conflict(error.Message);
            }
        }
    }

}
