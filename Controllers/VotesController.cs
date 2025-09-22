using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> ToVote(Votes model) {
            _context.Votes.Add(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}
