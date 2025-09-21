using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pharaoh_moto_club.Models;

namespace pharaoh_moto_club.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase {
        private readonly AppDbContext _context;

        public BoardsController(AppDbContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard(Board model) {
            _context.Boards.Add(model);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("{BoardId}")]
        public async Task<IActionResult> GetMembersOfBoard(int BoardId) {
            var membersOfTheBoard = await _context.Members
                .Where(c => c.BoardId == BoardId)
                .ToListAsync();
            return Ok(membersOfTheBoard);
        }

    }
}
