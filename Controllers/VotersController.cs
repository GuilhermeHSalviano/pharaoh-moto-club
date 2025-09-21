using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class VotersController : ControllerBase {
        private readonly AppDbContext _context;

        public VotersController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> ToVote(Voters model) {
            _context.Voters.Add(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
